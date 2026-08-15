using Atomic.Elements;
using System;
using UnityEngine;

namespace Game
{
    public sealed class TriggerInteractBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private TriggerEvents _trigger;
        private IGameEntity _entity;

        public void Init(IGameEntity entity)
        {
            _entity = entity;
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += OnTriggerEntered;
        }

        public void Dispose(IGameEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            _entity.InteractWith(collider);
        }
    }
}