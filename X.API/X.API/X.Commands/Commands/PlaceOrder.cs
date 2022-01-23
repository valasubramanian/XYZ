using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using X.Infrastructure;
using X.Domain;
using X.Domain.ServiceContracts;
using X.Domain.Models;
using ServiceBus = XYZ.Framework.Azure.ServiceBus;
using XYZ.Framework.Azure.ServiceBus.Topics;

namespace X.Service.Commands
{
    public class PlaceOrderContainer
    {
        public class PlaceOrderRequest : IFrameworkRequest<PlaceOrderResponse>
        {
            public Guid OrderId { get; set; }

            public string OrderStatus { get; set; }
        }

        public class PlaceOrderResponse : IFrameworkResponse
        {
            public string[] Errors { get; set; }

            public string[] Warnings { get; set; }

            public object Result { get; set; }

        }

        public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderRequest, PlaceOrderResponse>
        {
            private ServiceBus.IPublisher _publisher;
            public PlaceOrderCommandHandler(ServiceBus.IPublisher publisher)
            {
                _publisher = publisher;
            }

            public async Task<PlaceOrderResponse> Handle(PlaceOrderRequest request, CancellationToken cancellationToken)
            {
                PlaceOrderTopic placeOrderTopic = new PlaceOrderTopic
                {
                    OrderId = request.OrderId,
                    OrderStatus = request.OrderStatus
                };
                await _publisher.Publish<PlaceOrderTopic>(placeOrderTopic);
                return new PlaceOrderResponse() { Result = true };
            }
        }
    }
}
