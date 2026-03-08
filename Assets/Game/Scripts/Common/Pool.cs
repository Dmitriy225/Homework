using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private T _prefab;

        [SerializeField]
        private int _initialCount;

        private readonly Stack<T> _pool = new();

        private void Awake()
        {
            for (var i = 0; i < _initialCount; i++)
            {
                T item = CreateItem();
                _pool.Push(item);
            }
        }

        public void Return(T item)
        {
            if (_pool.Contains(item))
            {
                return;
            }

            OnReturn(item);
            _pool.Push(item);
        }

        public T Rent()
        {
            if (!_pool.TryPop(out T item))
            {
                item = CreateItem();
            }

            OnRent(item);
            return item;
        }

        protected virtual void OnCreate(T item)
        {
            item.gameObject.SetActive(true);
        }

        protected virtual void OnRent(T item)
        {
            item.gameObject.SetActive(true);
        }

        protected virtual void OnReturn(T item)
        {
            item.gameObject.SetActive(false);
        }

        private T CreateItem()
        {
            T item = Instantiate(_prefab, _container);
            OnCreate(item);
            return item;
        }
    }
}