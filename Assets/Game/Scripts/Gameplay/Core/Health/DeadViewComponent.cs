using UnityEngine;

namespace Game
{
    public sealed class DeadViewComponent : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private Transform _viewTransform;

        [SerializeField]
        private ParticleSystem _destroyEffectPrefab;

        private void OnEnable()
        {
            _healthComponent.OnEmptied += InstantiateEffect;
        }

        private void OnDisable()
        {
            _healthComponent.OnEmptied -= InstantiateEffect;
        }

        private void InstantiateEffect()
        {
            ParticleSystem prefab = _destroyEffectPrefab;
            GameObject.Instantiate(prefab, _viewTransform.position, prefab.transform.rotation);
        }
    }
}