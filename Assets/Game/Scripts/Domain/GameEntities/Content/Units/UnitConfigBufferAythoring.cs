using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitConfigBufferAythoring : MonoBehaviour
    {
        [SerializeField]
        private UnitCardsCatalog _catalog;

        public sealed class Baker : Baker<UnitConfigBufferAythoring>
        {
            public override void Bake(UnitConfigBufferAythoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                var buffer = AddBuffer<UnitConfigBuffer>(entity);

                foreach (var card in authoring._catalog.Cards)
                {
                    buffer.Add(new UnitConfigBuffer
                    {
                        Name = card.Name,
                        Price = card.Price,
                        Prefab = GetEntity(card.Prefab, TransformUsageFlags.None)
                    });
                }
            }
        }
    }
}