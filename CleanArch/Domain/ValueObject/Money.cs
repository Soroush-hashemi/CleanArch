namespace Domain.Base;

public class Money : BaseValueObject
{
    public int Value { get; }
    public Money(int Rial)
    {
        Value = Rial;
    }

    public static Money FromRial(int value)
    {
        return new Money(value);
    }

    public static Money FromTooman(int value)
    {
        return new Money(value* 10);
    }

    public static Money operator +(Money FirstMoney, Money SecondMoney)
    {
        return new Money(FirstMoney.Value + SecondMoney.Value);
    }

    public static Money operator -(Money FirstMoney, Money SecondMoney)
    {
        return new Money(FirstMoney.Value + SecondMoney.Value);
    }
}

