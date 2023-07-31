using Domain.Bases;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Exception
{
    public class NullOrEmptyException : BaseDomainException
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

        public static void CheckObject(object Value, string NameofField)
        {
            if (IsNullOrEmptyObj(Value))
                throw new NotImplementedException($"{NameofField} is null");
        }


        private static bool IsNullOrEmptyObj([NotNullWhen(false)] object? value)
        {
            return (value == null) ? true : false;
        }


    }
}
