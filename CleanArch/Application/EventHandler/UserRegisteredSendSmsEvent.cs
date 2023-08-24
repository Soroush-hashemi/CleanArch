using Application.Command.SmsService;
using Domain.Events;

namespace Application.Command.EventHandler;
public class UserRegisteredSendSmsEvent
{
    private ISmsService _smsService;
    public UserRegisteredSendSmsEvent(ISmsService smsService)
    {
        _smsService = smsService;
    }
    public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
    {
        _smsService.SendSms(new SmsBody());
        await Task.CompletedTask;
    }
}