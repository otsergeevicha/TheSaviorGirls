﻿using System;
using Services.SaveLoad;
using Services.Wallet;

namespace WalletLogic
{
    public class Wallet : IWallet
    {
        private ISave _saveLoadService;
        private int _settlementAccount;

        public void Construct(ISave saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _settlementAccount = _saveLoadService.AccessProgress().DataWallet.Read();
        }

        public event Action<int> Changed;

        public bool Check(int pricePurchase) => 
            _settlementAccount - pricePurchase >= 0;

        public void Spend(int price)
        {
            _settlementAccount -= Math.Clamp(price, 0, int.MaxValue);
            Notify();
            WritingSave();
        }

        public void Apply(int amountReplenishment)
        {
            _settlementAccount += amountReplenishment;
            Notify();
            WritingSave();
        }

        private void WritingSave()
        {
            _saveLoadService.AccessProgress().DataWallet.Record(_settlementAccount);
            _saveLoadService.Save();
        }

        private void Notify() => 
            Changed?.Invoke(_settlementAccount);
    }
}