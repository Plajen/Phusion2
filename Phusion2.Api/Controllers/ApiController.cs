using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phusion2.Application.Interfaces;
using Phusion2.Application.ViewModels.Response;
using Phusion2.Domain.Core.Bus;
using Phusion2.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Phusion2.Api.Controllers
{
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected ApiController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected BaseResponse<T> BaseResponse<T>(T data, int? dataCount = null, int? totalCount = null, IBaseParams parameters = null)
        {
            return new BaseResponse<T>(data, dataCount, totalCount, parameters, Notifications.ToList());
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var erroMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected void ExcludePropertiesInValidation(params string[] properties)
        {
            if (ModelState.IsValid)
                return;

            foreach (var property in properties)
            {
                if (ModelState.ContainsKey(property))
                {
                    ModelState.Remove(property);
                }
            }
        }
    }
}
