using UnityEngine;

namespace CodeBase.Services.WalletService
{
    [CreateAssetMenu(menuName = "Configs/Wallet/Currency")]
    public class CurrencyConfig : ScriptableObject
    {
        public CurrencyType Type;
        public Sprite Icon;
        public string Description;
    }
}