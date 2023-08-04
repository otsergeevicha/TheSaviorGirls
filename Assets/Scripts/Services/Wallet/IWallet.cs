using System;
using Services.SaveLoad;

namespace Services.Wallet
{
    public interface IWallet
    {
        void Construct(ISave saveLoadService);
        
        event Action<int> Changed;
        
        bool Check(int pricePurchase);

        void Spend(int price);

        void Apply(int amountReplenishment);

    }
}