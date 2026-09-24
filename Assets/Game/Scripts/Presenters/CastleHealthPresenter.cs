using System;
using Unity.Collections;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace SampleGame
{
    using Unity.Collections;
    using Unity.Entities;
    using UnityEngine;

    public sealed class CastleHealthPresenter : MonoBehaviour
    {
        [SerializeField]
        private HealthView _view;

        [SerializeField]
        private TeamType _team;

        private EntityManager _entityManager;
        private EntityQuery _query;
        private Entity _castle;

        private void Start()
        {
            var world = World.DefaultGameObjectInjectionWorld;
            _entityManager = world.EntityManager;
            _query = _entityManager.CreateEntityQuery(
                typeof(Castle), typeof(Team), typeof(Health)
            );
        }

        private void LateUpdate()
        {
            if (!TryGetCastle(out _castle))
                return;

            if (!_entityManager.HasComponent<Health>(_castle))
                return;

            var health = _entityManager.GetComponentData<Health>(_castle);
            _view.HealthProgress = health.GetPercent();
            _view.HealthText = $"{health.Current}/{health.Max}";
        }

        private bool TryGetCastle(out Entity castle)
        {
            if (_castle != Entity.Null && _entityManager.Exists(_castle))
            {
                castle = _castle;
                return true;
            }

            using var entities = _query.ToEntityArray(Allocator.Temp);
            using var teams = _query.ToComponentDataArray<Team>(Allocator.Temp);

            for (int i = 0; i < entities.Length; i++)
            {
                if (teams[i].Value == _team)
                {
                    _castle = entities[i];
                    castle = _castle;
                    return true;
                }
            }

            _castle = Entity.Null;
            castle = Entity.Null;
            return false;
        }
    }
}