﻿using Domain.Base;
using Domain.Entities;
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

        public static void CheckMoney(Money money, string NameofField)
        {
            if (money == new Money(0))
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
