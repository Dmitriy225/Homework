using Modules.UI;
using Modules.Utils;
using System;
using UnityEngine;

namespace Game
{
    public sealed class HealthPresenter : MonoBehaviour
    {
        [SerializeField]
        private HealthView _view;

        [SerializeField]
        private PlayerShip _playerShip;

        private void OnEnable()
        {
            _playerShip.OnHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _playerShip.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int current, int max)
        {
            _view.SetHealth(current, max);
        }
    }
}