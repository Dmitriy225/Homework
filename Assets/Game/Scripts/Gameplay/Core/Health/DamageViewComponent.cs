using DG.Tweening;
using UnityEngine;

namespace Game
{
    public sealed class DamageViewComponent : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private Renderer _renderer;

        [SerializeField]
        private DamageViewConfig _viewConfig;

        private Material _material;
        private Tweener _damageTweener;

        private void Awake()
        {
            _material = _renderer.material;    
        }

        private void OnEnable()
        {
            _healthComponent.OnReduced += AnimateDamage;
        }

        private void OnDisable()
        {
            _healthComponent.OnReduced -= AnimateDamage;
        }

        private void AnimateDamage()
        {
            if (_damageTweener.IsActive())
            {
                _damageTweener.Kill();
            }

            _damageTweener = DOVirtual.Float(
                0f,
                1f,
                _viewConfig.HitDuration,
                progress => _material.SetFloat(_viewConfig.HitPropertyName,
                    _viewConfig.HitAnimationCurve.Evaluate(progress))
            ).SetLink(_renderer.gameObject);
        }
    }
}