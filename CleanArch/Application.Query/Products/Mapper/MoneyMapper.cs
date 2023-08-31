using Domain.Base;
using ReadModel.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query.Products.Mapper
{
    public class MoneyMapper
    {
        public static MoneyReadModel FromMoney(Money money)
        {
            return new MoneyReadModel(money.Value);
        }
    }
}
