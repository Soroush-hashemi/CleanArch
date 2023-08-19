using Application.Command.SmsService;
using Domain.Events;
using MediatR;

namespace Application.Command.EventHandler
{
    public class ProductCreatedSendSmsEvant : INotificationHandler<ProductCreated>
    {
        private ISmsService _smsService;
        public ProductCreatedSendSmsEvant(ISmsService smsService)
        {
            _smsService = smsService;
        }
        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            _smsService.SendSms(new SmsBody());
            await Task.CompletedTask;
        }
    }
}
