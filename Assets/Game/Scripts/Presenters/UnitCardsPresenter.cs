using System;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitCardsPresenter : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private UnitCardView _prefab;

        [SerializeField]
        private UnitCardsCatalog _catalog;

        private void Start()
        {
            foreach (var cardConfig in _catalog.Cards)
            {
                var view = Instantiate(_prefab, _container);
                var presenter = view.GetComponent<UnitCardPresenter>();
                presenter.Initialize(cardConfig);
            }
        }
    }
}