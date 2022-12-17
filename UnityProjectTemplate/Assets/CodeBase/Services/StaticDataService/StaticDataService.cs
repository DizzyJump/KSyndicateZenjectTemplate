using UnityEngine;

namespace CodeBase.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        public void Initialize()
        {
            // load your configs here
            Debug.Log("Static data loaded");
        }
    }
}