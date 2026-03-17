using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetView : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        public void SetImageIcon(Sprite icon)
        {
            _image.sprite = icon;
        }
    }
}