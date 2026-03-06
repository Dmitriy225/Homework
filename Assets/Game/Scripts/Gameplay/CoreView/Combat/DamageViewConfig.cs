using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "DamageViewConfig",
        menuName = "Game/Configs/View/New DamageViewConfig"
    )]
    public sealed class DamageViewConfig : ScriptableObject
    {
        [field: SerializeField]
        public AnimationCurve HitAnimationCurve { get; private set; }

        [field: SerializeField]
        public string HitPropertyName { get; private set; } = "_HitBlend";

        [field: SerializeField]
        public float HitDuration { get; private set; } = 0.2f;
    }
}