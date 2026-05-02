using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetPopup : MonoBehaviour
    {
        public event UnityAction OnCloseClicked
        {
            add { _closeButton.onClick.AddListener(value); }
            remove { _closeButton.onClick.RemoveListener(value); }
        }

        public event UnityAction OnUpgradeClicked
        {
            add { _upgradeButton.onClick.AddListener(value); }
            remove { _upgradeButton.onClick.RemoveListener(value); }
        }

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private Image _image;

        [SerializeField]
        private TMP_Text _title;

        [SerializeField]
        private TMP_Text _population;

        [SerializeField]
        private TMP_Text _level;

        [SerializeField]
        private TMP_Text _income;

        [SerializeField]
        private Button _upgradeButton;

        [SerializeField]
        private TMP_Text _upgradeButtonText;

        [SerializeField]
        private GameObject _price;

        [SerializeField]
        private TMP_Text _priceText;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetIcon(Sprite icon)
        {
            _image.sprite = icon;
        }

        public void SetTitle(string text)
        {
            _title.text = text;
        }

        public void SetPopulation(string text)
        {
            _population.text = text;
        }

        public void SetLevel(string text)
        {
            _level.text = text;
        }

        public void SetIncome(string text)
        {
            _income.text = text;
        }

        public void SetUpgradeButtonInteractable(bool interactable)
        {
            _upgradeButton.interactable = interactable;
        }

        public void SetUpgradeButtonText(string text)
        {
            _upgradeButtonText.text = text;
        }

        public void SetPriceActive(bool active)
        {
            _price.SetActive(active);
        }

        public void SetPrice(string text)
        {
            _priceText.text = text;
        }
    }
}