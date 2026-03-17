using System.Collections;
using TMPro;
using UnityEngine;

namespace Game
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _valueTMP;

        [SerializeField]
        private float _animationDuration = 1.0f;

        private Coroutine _animationCoroutine;

        public void OnDisable()
        {
            StopAnimations();
        }

        public void ChangeValue(string value)
        {
            StopAnimations();
            _valueTMP.text = value;
        }

        public void AddValue(int value, int range)
        {
            StopAnimations();
            _animationCoroutine = StartCoroutine(AnimateValue(value - range, range));
        }

        public void RemoveValue(string value)
        {
            StopAnimations();
            _valueTMP.text = value;
        }

        private IEnumerator AnimateValue(int startValue, int range)
        {
            float progress = 0;

            while (progress <= 1)
            {
                yield return null;
                progress = Mathf.Min(1, progress + Time.deltaTime / _animationDuration);
                int current = Mathf.RoundToInt(startValue + range * progress);
                _valueTMP.text = current.ToString();
            }

            _valueTMP.text = (startValue + range).ToString();
        }

        private void StopAnimations()
        {
            if (_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
                _animationCoroutine = null;
            }
        }
    }
}