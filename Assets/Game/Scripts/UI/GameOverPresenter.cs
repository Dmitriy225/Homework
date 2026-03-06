using Modules.UI;
using System;
using UnityEngine;

namespace Game
{
    public sealed class GameOverPresenter : MonoBehaviour
    {
        [SerializeField]
        GameOverView _view;

        [SerializeField]
        PlayerShip _playerShip;

        private void OnEnable()
        {
            _playerShip.OnDied += _view.Show;
        }

        private void OnDisable()
        {
            _playerShip.OnDied -= _view.Show;
        }
    }
}