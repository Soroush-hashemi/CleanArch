namespace Domain;

public interface IOrderDomainService
{
    // برای بررسی کردن این‌که محصول وجود دارد یا نه 
    bool IsProductExist(Guid ProductId);
}
