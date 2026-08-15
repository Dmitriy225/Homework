using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class TransformInstaller : IEntityInstaller<IGameEntity>
    {
        private readonly Transform _transform;

        public TransformInstaller(Transform transform)
        {
            _transform = transform;
        }

        public void Install(IGameEntity entity)
        {
            entity.AddPosition(
                new InlineVariable<Vector3>(
                    () => _transform.position,
                    position => _transform.position = position
                )
            );
            entity.AddRotation(
                new InlineVariable<Quaternion>(
                    () => _transform.rotation,
                    rotation => _transform.rotation = rotation
                )
            );
        }
    }
}