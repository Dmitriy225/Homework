using Modules.UI;
using System;
using UnityEngine;

namespace Game
{
    public sealed class GameOverPresenter : MonoBehaviour
    {
        [SerializeField]
        private GameOverView _view;

        [SerializeField]
        private HealthComponent _healthComponent;

        private void OnEnable()
        {
            _healthComponent.OnEmptied += _view.Show;
        }

        private void OnDisable()
        {
            _healthComponent.OnEmptied -= _view.Show;
        }
    }
}