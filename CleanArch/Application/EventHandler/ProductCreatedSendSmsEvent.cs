using Application.Command.SmsService;
using Domain.Entities.ProductAgg.Events;
using MediatR;

namespace Application.Command.EventHandler;

public class ProductCreatedSendSmsEvent : INotificationHandler<ProductCreated>
{   // قبل از رفتن به ایونت ها در کوئری اینجا اجرا میشه
    private ISmsService _smsService;
    public ProductCreatedSendSmsEvent(ISmsService smsService)
    {
        _smsService = smsService;
    }
    public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
        _smsService.SendSms(new SmsBody());
        await Task.CompletedTask;
    }
}