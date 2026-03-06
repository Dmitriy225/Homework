using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "MovementConfig",
        menuName = "Game/Configs/Core/New MovementConfig")]
    public sealed class MovementConfig : ScriptableObject
    {
        [field: SerializeField]
        public float Speed { get; private set; } = 1;
    }
}