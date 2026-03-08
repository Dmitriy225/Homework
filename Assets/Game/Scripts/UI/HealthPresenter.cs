using Modules.UI;
using UnityEngine;

namespace Game
{
    public sealed class HealthPresenter : MonoBehaviour
    {
        [SerializeField]
        private HealthView _view;

        [SerializeField]
        private HealthComponent _healthComponent;

        private void OnEnable()
        {
            _healthComponent.OnStateChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _healthComponent.OnStateChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int current, int max)
        {
            _view.SetHealth(current, max);
        }
    }
}