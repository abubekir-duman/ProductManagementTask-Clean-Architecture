using ProductManagementTask.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Domain.ValueObjects;
public sealed record Money(decimal Amount,MoneyTypeEnum currency)
{
    public static Money operator +(Money a, Money b)
    {
        if(a.currency!=b.currency)
        {
            throw new ArgumentException("Para birimleri birbirinden farklı değerler toplanamaz");
        }

        return new(a.Amount+b.Amount,a.currency);
    }

    public static Money Zero() => new(0, MoneyTypeEnum.TL);
    public static Money Zero(MoneyTypeEnum currency)=>new(0,currency);
    public bool IsZero() => this == Zero(currency);
}



