using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.UI.Windows.PrivatePolicyAccept
{
    [CreateAssetMenu(menuName = "Configs/UI/Popups/PolicyAcceptPopupConfig")]
    public class PolicyAcceptPopupConfig : ScriptableObject
    {
        [TextArea(5, 10)] public string PolicyText;
        [TextArea(1, 3)] public string AgreeText;
        [TextArea(1, 1)]public string ButtonText;
    }
}