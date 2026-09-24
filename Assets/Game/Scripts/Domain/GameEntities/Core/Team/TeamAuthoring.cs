using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class TeamAuthoring : MonoBehaviour
    {
        [SerializeField]
        private TeamType _value;

        public sealed class Baker : Baker<TeamAuthoring>
        {
            public override void Bake(TeamAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Team { Value = authoring._value });
            }
        }
    }
}