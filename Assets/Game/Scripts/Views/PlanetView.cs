using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetView : MonoBehaviour
    {
        [SerializeField]
        private Image _iconImage;

        public void SetIcon(Sprite icon)
        {
            _iconImage.sprite = icon;
        }
    }
}