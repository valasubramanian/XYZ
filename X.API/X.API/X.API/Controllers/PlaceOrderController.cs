using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.Service.Commands;

namespace X.API.Controllers
{
    // {"orderId":"0f835d4e-4d20-4cb0-b724-a21b3fff4d22","orderStatus":"NEW"}
    [ApiController]
    public class PlaceOrderController : ApiController<PlaceOrderContainer.PlaceOrderRequest, PlaceOrderContainer.PlaceOrderResponse>
    {
        public PlaceOrderController(IMediator mediator) : base(mediator) { }
    }
}