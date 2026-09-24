using TMPro;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public class MoneyPresenter : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _money;

        private EntityManager _entityManager;
        private EntityQuery _query;

        private void Start()
        {
            var world = World.DefaultGameObjectInjectionWorld;
            _entityManager = world.EntityManager;
            var queryDescription = new EntityQueryDesc
            {
                All = new ComponentType[] { typeof(Player), typeof(Money), typeof(Team) },
                None = new ComponentType[] { typeof(Enemy) }
            };
            _query = _entityManager.CreateEntityQuery(queryDescription);
        }

        private void Update()
        {
            if (
                !_query.TryGetSingletonEntity<Money>(out var playerEntity)
                || playerEntity == Entity.Null
                || !_entityManager.Exists(playerEntity)
            )
            {
                return;
            }

            var coins = _entityManager.GetComponentData<Money>(playerEntity);
            _money.text = coins.Value.ToString();
        }
    }
}