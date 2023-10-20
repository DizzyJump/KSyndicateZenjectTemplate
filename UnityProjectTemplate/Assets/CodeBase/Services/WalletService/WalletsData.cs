
using System;
using System.Collections.Generic;
using CodeBase.Data;

namespace CodeBase.Services.WalletService
{
    [Serializable]
    public class WalletsData : DictionarySerializeContainer<int, long>
    {
        public WalletsData(Dictionary<int, long> dictionary) : base(dictionary)
        {
        }
    }
}