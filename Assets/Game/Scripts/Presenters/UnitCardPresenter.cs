using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitCardPresenter : MonoBehaviour
    {
        [SerializeField]
        private UnitCardView _view;

        private UnitCardConfig _config;
        private EntityManager _entityManager;
        private Entity _playerEntity;
        private EntityQuery _query;

        public void Start()
        {
            var world = World.DefaultGameObjectInjectionWorld;
            _entityManager = world.EntityManager;
            var queryDescription = new EntityQueryDesc
            {
                All = new ComponentType[] { typeof(Player), typeof(Money), typeof(Team) },
                None = new ComponentType[] { typeof(Enemy) },

            };
            _query = _entityManager.CreateEntityQuery(queryDescription);
        }

        public void Initialize(UnitCardConfig config)
        {
            _config = config;
            _view.SetIcon(_config.Icon);
            _view.SetName(_config.Name);

        }

        public void OnEnable()
        {
            _view.OnClicked += OnClicked;
        }

        public void OnDisable()
        {
            _view.OnClicked -= OnClicked;
        }

        public void Update()
        {
            if (
                !_query.TryGetSingletonEntity<Money>(out _playerEntity)
                || _playerEntity == Entity.Null
                || !_entityManager.Exists(_playerEntity)
            )
            {
                return;
            }
            var money = _entityManager.GetComponentData<Money>(_playerEntity);
            _view.SetEnabled(money.Value >= _config.Price);
            _view.SetProgressCaption(string.Format("{0}/{1}", money.Value, _config.Price));
            _view.SetProgress(money.Value / (float)_config.Price);
        }

        private void OnClicked()
        {
            var spawnUnitRequest = _entityManager.GetComponentData<SpawnUnitRequest>(_playerEntity);
            spawnUnitRequest.UnitName = _config.Name;
            _entityManager.SetComponentData(_playerEntity, spawnUnitRequest);
            _entityManager.SetComponentEnabled<SpawnUnitRequest>(_playerEntity, true);
        }
    }
}