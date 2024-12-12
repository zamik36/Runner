using UnityEngine;
using NaughtyAttributes;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/SDKConfig")]
    public sealed class SDKConfig : ScriptableObject
    {
        public bool AnimateInterCountdown;
        public int InterCD;
        public int RewardCD;
        public int RateUsDelay;
    }
}