using UnityEngine;
using NaughtyAttributes;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/UIConfig")]
    public sealed class UIConfig : ScriptableObject
    {
        // Example
        // [SerializeField] [BoxGroup("Moving")] private float moveSpeed;
        // public float MoveSpeed => moveSpeed;
        public Sprite HapticOn;
        public Sprite HapticOff;
    }
}