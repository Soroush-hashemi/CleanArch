using ReadModel.Bases;
using ReadModel.ValueObject;
using System.Diagnostics.CodeAnalysis;

namespace ReadModel.Exception
{
    public class NullOrEmptyException : BaseReadModelException
    {
        public NullOrEmptyException()
        {

        }

        public NullOrEmptyException(string message)
        {

        }

        public static void CheckString(string Value, string NameofField)
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new NotImplementedException($"{NameofField} is null");
            if (string.IsNullOrEmpty(Value))
                throw new NotImplementedException($"{NameofField} is null");
        }

        public static void CheckMoney(MoneyReadModel money, string NameofField)
        {
            if (money == new MoneyReadModel(0))
                throw new NotImplementedException($"{NameofField} is not valid");
        }

        public static void CheckObject(object Value)
        {
            if (IsNullOrEmptyObj(Value))
                throw new NotImplementedException("is not valid");
        }

        private static bool IsNullOrEmptyObj([NotNullWhen(false)] object? value)
        {
            return (value == null) ? true : false;
        }
    }
}
