using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class SpawnPositionBufferAuthoring : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _points;

        public sealed class Baker : Baker<SpawnPositionBufferAuthoring>
        {
            public override void Bake(SpawnPositionBufferAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                var buffer = AddBuffer<SpawnPositionBuffer>(entity);

                foreach (var point in authoring._points)
                {
                    buffer.Add(new SpawnPositionBuffer { Position = point.position });
                }
            }
        }
    }
}