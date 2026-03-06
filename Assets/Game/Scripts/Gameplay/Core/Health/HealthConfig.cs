using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "HealthConfig",
        menuName = "Game/Configs/Core/New HealthConfig")]
    public sealed class HealthConfig : ScriptableObject
    {
        [field: SerializeField]
        public int Health { get; private set; } = 5;
    }
}