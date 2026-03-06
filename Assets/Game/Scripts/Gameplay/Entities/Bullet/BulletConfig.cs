using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "BulletConfig",
        menuName = "Game/Configs/Core/New BulletConfig"
    )]
    public sealed class BulletConfig : ScriptableObject
    {
        [field: SerializeField]
        public float Speed { get; private set; } = 7.0f;

        [field: SerializeField]
        public int Damage { get; private set; } = 1;
    }
}