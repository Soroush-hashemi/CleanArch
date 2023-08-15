using Domain.Exception;

namespace Domain.Base;

public class Money : BaseValueObject
{
    private Money()
    {
        
    }
    public int Value { get; }
    public Money(int Rial)
    {
        if (Rial < 0)
            throw new NotImplementedException("money is not valid");
        Value = Rial;
    }

    public static Money FromRial(int value)
    {
        return new Money(value);
    }

    public static Money FromTooman(int value)
    {
        return new Money(value / 10);
    }

    public static Money operator +(Money FirstMoney, Money SecondMoney)
    {
        return new Money(FirstMoney.Value + SecondMoney.Value);
    }

    public static Money operator -(Money FirstMoney, Money SecondMoney)
    {
        return new Money(FirstMoney.Value - SecondMoney.Value);
    }
}

