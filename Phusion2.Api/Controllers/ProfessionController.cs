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
    public class ProfessionController : ApiController
    {
        private readonly IProfessionAppService _professionAppService;

        public ProfessionController(
            IProfessionAppService professionAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _professionAppService = professionAppService;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<ProfessionViewModel>>> Get([FromQuery] ProfessionParams parameters)
        {
            var data = await _professionAppService.GetAllAsync(parameters);
            return BaseResponse(data, null, null, parameters);
        }

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<ProfessionViewModel>> Get(int id)
        {
            return BaseResponse(await _professionAppService.GetByIdAsync(id));
        }
    }
}
