﻿using System.Collections.Generic;
using VendingMachine.Core.Models;

namespace VendingMachine.BLL.Factories
{
    // кошелек пользователя
    public class PurseCustomer : PurseBase
    {
        public PurseCustomer(List<Coin> coins) : base(coins)
        {
        }

        // заплатить сумму подходящими монетами
        public override IEnumerable<Coin> Pay(int summ)
        {
            IEnumerable<Coin> resultList = null;
            if (ValidateAmountCoins(summ))
            {
                resultList = GetCoins(summ);
                // забираем монетки
                RemoveCoins(resultList);
            }
            return resultList;
        }

        // заплатить определенным типом монет
        public override IEnumerable<Coin> Pay(IEnumerable<Coin> coins)
        {
            IEnumerable<Coin> resultList = null;
            if (ValidateAmountCoins(coins))
            {
                resultList = GetCoins(coins);
                // забираем монетки
                RemoveCoins(resultList);
            }
            return resultList;
        }

        // пополнить свой кошелек
        public override void Replenish(IEnumerable<Coin> coins)
        {
            AddCoins(coins);
        }
    }
}