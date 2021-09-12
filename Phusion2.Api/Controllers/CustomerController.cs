using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phusion2.Application.Interfaces;
using Phusion2.Application.Parameters;
using Phusion2.Application.ViewModels;
using Phusion2.Application.ViewModels.Response;
using Phusion2.Domain.Core.Bus;
using Phusion2.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phusion2.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<CustomerViewModel>>> Get([FromQuery] CustomerParams parameters)
        {
            var data = await _customerAppService.GetAsync(parameters);
            var dataCount = await _customerAppService.GetCountAsync(parameters);
            var totalCount = await _customerAppService.GetCountAsync(new CustomerParams());
            return BaseResponse(data, dataCount, totalCount, parameters);
        }

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<CustomerViewModel>> Get(int id)
        {
            return BaseResponse(await _customerAppService.GetByIdAsync(id));
        }

        [HttpGet("count")]
        public async Task<BaseResponse<int>> Count([FromQuery] CustomerParams parameters)
        {
            return BaseResponse(await _customerAppService.GetCountAsync(parameters));
        }

        [HttpPost]
        public async Task<BaseResponse<CustomerViewModel>> Post([FromBody] CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return BaseResponse(customer);
            }

            return BaseResponse(await _customerAppService.RegisterAsync(customer));
        }

        [HttpPut]
        public async Task<BaseResponse<CustomerViewModel>> Put([FromBody] CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return BaseResponse(customer);
            }
            return BaseResponse(await _customerAppService.UpdateAsync(customer));
        }

        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<int>> Delete(int id)
        {
            return BaseResponse(await _customerAppService.RemoveAsync(id));
        }
    }
}
