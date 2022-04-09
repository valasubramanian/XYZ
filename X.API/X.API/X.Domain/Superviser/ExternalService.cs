using System.Linq;
using System.Collections;
using System;
using System.Collections.Generic;
using X.Domain.ServiceContracts;
using X.Domain.Models;
using X.Domain.Entities;
using X.Domain.DataContracts;
using Newtonsoft.Json;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace X.Domain.Superviser
{
    public class ExternalService : IExternalService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExternalService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private async Task<string> GetAccessToken()
        {
            string accessToken = "";
            var idpClient = _httpClientFactory.CreateClient("IdentityServerClient");
            var discoveryDocumentResponse = await idpClient.GetDiscoveryDocumentAsync(idpClient.BaseAddress.AbsoluteUri);
            if(!discoveryDocumentResponse.IsError)
            {
                var tokenResponse = await idpClient.RequestClientCredentialsTokenAsync(
                    new ClientCredentialsTokenRequest
                    {
                        Address = discoveryDocumentResponse.TokenEndpoint,
                        ClientId = "client-id-453434-m2m",
                        ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                        Scope = "y.api.access"
                    }
                );

                if(!tokenResponse.IsError)
                    accessToken = tokenResponse.AccessToken;
            } 

            return accessToken;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            string accessToken = await GetAccessToken();
            var client = _httpClientFactory.CreateClient("Y.API");
            client.SetBearerToken(accessToken);

            var response = await client.GetAsync("/api/getproducts");
            if (response.IsSuccessStatusCode)
            {
               var responseMessage = await response.Content.ReadAsStringAsync();
            }

            return null;
        }

        public int UpdateProduct()
        {
            return 0;
        }
    }
}
