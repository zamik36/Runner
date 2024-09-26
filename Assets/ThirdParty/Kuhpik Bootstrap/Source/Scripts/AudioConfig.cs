using UnityEngine;
using NaughtyAttributes;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/AudioConfig")]
    public sealed class AudioConfig : ScriptableObject
    {
        public AudioClip Money;
    }
}