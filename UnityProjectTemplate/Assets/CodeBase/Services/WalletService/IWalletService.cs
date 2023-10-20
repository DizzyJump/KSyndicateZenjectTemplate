namespace CodeBase.Services.WalletService
{
    public interface IWalletService
    {
        long GetAmount(CurrencyType currency);
        void SetAmount(CurrencyType currency, long amount);
        void AddAmount(CurrencyType currency, long amount);
        bool TrySpend(CurrencyType currency, long price);
    }
}