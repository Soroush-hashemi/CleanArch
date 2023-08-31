using ReadModel.Bases;

namespace ReadModel.ValueObject
{
    public class MoneyReadModel : BaseValueObject
    {
        private MoneyReadModel()
        {

        }
        public int Value { get; }
        public MoneyReadModel(int Rial)
        {
            if (Rial < 0)
                throw new NotImplementedException("money is not valid");
            Value = Rial;
        }

        public int ToInt()
        {
            return Value;
        }

        public static MoneyReadModel FromRial(int value)
        {
            return new MoneyReadModel(value);
        }

        public static MoneyReadModel FromTooman(int value)
        {
            return new MoneyReadModel(value / 10);
        }

        public static MoneyReadModel operator +(MoneyReadModel FirstMoney, MoneyReadModel SecondMoney)
        {
            return new MoneyReadModel(FirstMoney.Value + SecondMoney.Value);
        }

        public static MoneyReadModel operator -(MoneyReadModel FirstMoney, MoneyReadModel SecondMoney)
        {
            return new MoneyReadModel(FirstMoney.Value - SecondMoney.Value);
        }
    }
}
