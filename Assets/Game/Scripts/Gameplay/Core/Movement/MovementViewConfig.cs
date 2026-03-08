using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "MovementViewConfig",
        menuName = "Game/Configs/View/New MovementViewConfig"
    )]
    public sealed class MovementViewConfig : ScriptableObject
    {
        [field: SerializeField]
        public float MoveRotationAngle { get; private set; } = 30f;

        [field: SerializeField]
        public float MoveSpeed { get; private set; } = 5;
    }
}