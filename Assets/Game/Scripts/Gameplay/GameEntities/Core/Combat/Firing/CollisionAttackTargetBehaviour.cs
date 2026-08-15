using Atomic.Elements;
using System;
using UnityEngine;

namespace Game
{
    public sealed class CollisionAttackTargetBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private IGameEntity _entity;
        private IRequest _fireRequest;
        private CollisionEvents _collisionEvents;

        public void Init(IGameEntity entity)
        {
            _entity = entity;
            _fireRequest = entity.GetFireRequest();
            _collisionEvents = entity.GetCollisionEvents();
            _collisionEvents.OnStay += OnCollisionStay;
        }

        public void Dispose(IGameEntity entity)
        {
            _collisionEvents.OnStay -= OnCollisionStay;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (_entity.HasTarget(collision.collider))
            {
                _fireRequest.Invoke();
            }
        }
    }
}