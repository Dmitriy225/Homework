using UnityEngine;

namespace Game
{
    public sealed class DeadViewComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _viewTransform;

        [SerializeField]
        private ParticleSystem _destroyEffectPrefab;

        public void InstantiateEffect()
        {
            ParticleSystem prefab = _destroyEffectPrefab;
            GameObject.Instantiate(prefab, _viewTransform.position, prefab.transform.rotation);
        }
    }
}