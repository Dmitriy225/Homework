using Modules.UI;
using Sirenix.Config;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetView : MonoBehaviour
    {
        public event Action OnClicked
        {
            add { _button.OnClick += value; }
            remove { _button.OnClick -= value; }
        }

        [SerializeField]
        private SmartButton _button;

        [SerializeField]
        private Image _iconImage;

        [SerializeField]
        private GameObject _lock;

        [SerializeField]
        private GameObject _coin;

        [SerializeField]
        private GameObject _income;

        [SerializeField]
        private Image _incomeProgressImage;

        [SerializeField]
        private TMP_Text _incomeTimeTMP;

        [SerializeField]
        private GameObject _price;

        [SerializeField]
        private TMP_Text _priceTMP;

        public void SetIcon(Sprite icon)
        {
            _iconImage.sprite = icon;
        }

        public void SetLockActive(bool locked)
        {
            _lock.SetActive(locked);
            _price.SetActive(locked);
        }

        public void SetIncomeActive(bool active)
        {
            _income.SetActive(active);
        }

        public void SetCoinActive(bool active)
        {
            _coin.SetActive(active);
        }

        public void SetPrice(string text)
        {
            _priceTMP.text = text;
        }

        public void SetIncomeProgress(float progress)
        {
            _incomeProgressImage.fillAmount = progress;
        }

        public void SetIncomeTime(string remainingTime)
        {
            _incomeTimeTMP.text = remainingTime;
        }
    }
}