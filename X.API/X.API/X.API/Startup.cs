using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using X.Service;
using X.Service.ServiceBusTopicHandlers;
using X.Infrastructure;
using X.Infrastructure.Context;
using X.Domain;
using XYZ.Framework.Azure.ServiceBus;
using XYZ.Framework.Azure.ServiceBus.Managers;
using XYZ.Framework.Azure.ServiceBus.Topics;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace X.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddControllers();

            services.AddHttpClient("IdentityServerClient", client => {
                client.BaseAddress = new Uri("https://localhost:5001");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient("Y.API", client => {
                client.BaseAddress = new Uri("https://localhost:8083");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.Authority = "https://localhost:5001";
                        options.Audience = "x.api";
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true
                        };
                    });
            
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = 
                    new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddDomainServices();

            services.AddLocator();

            services.AddScoped<ILocator, Locator>();

            services.AddDbContext<XDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XDB")));
            // .GetSection("ConnectionStrings").GetValue<string>("XDB")));

            services.AddDataRepositaries();

            services.AddAzureServiceBus(Configuration);

            services.AddScoped<DeliveryStatusHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            RegisterServiceBusSubscription(app);
        }

        private void RegisterServiceBusSubscription(IApplicationBuilder app)
        {
            var subscriptionManager = app.ApplicationServices.GetRequiredService<ISubscriptionManager>();
            subscriptionManager.SubscribeTopic<DeliveryStatusTopic, DeliveryStatusHandler>();
        }
    }
}
