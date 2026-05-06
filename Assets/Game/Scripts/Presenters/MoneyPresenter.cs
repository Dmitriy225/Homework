using Game.Views;
using Modules.Money;
using System;
using Zenject;

namespace Game.Presenters
{
    public sealed class MoneyPresenter : IInitializable, IDisposable
    {
        private readonly CurrencyView _view;
        private readonly IMoneyStorage _storage;
        private int _currentValue;

        public MoneyPresenter(CurrencyView view, IMoneyStorage storage)
        {
            _view = view;
            _storage = storage;
        }

        public void Initialize()
        {
            UpdateMoney(_storage.Money);
            //_storage.OnMoneyChanged += OnMoneyChanged;
            //_storage.OnMoneyEarned += OnMoneyEarned;
            _storage.OnMoneySpent += OnMoneySpent;
        }

        public void Dispose()
        {
            //_storage.OnMoneyChanged -= OnMoneyChanged;
            //_storage.OnMoneyEarned -= OnMoneyEarned;
            _storage.OnMoneySpent -= OnMoneySpent;
        }

        //private void OnMoneyChanged(int newValue, int previousValue)
        //{
        //    if (_currentValue == _storage.Money)
        //    {
        //        return;
        //    }

        //    UpdateMoney(newValue);
        //}

        //private void OnMoneyEarned(int value, int range)
        //{
        //    _currentValue = value;
        //    _view.AddValue(value, range);
        //}

        private void OnMoneySpent(int value, int range)
        {
            _currentValue = value;
            _view.RemoveValue(value.ToString());
        }

        private void UpdateMoney(int value)
        {
            _currentValue = value;
            _view.ChangeValue(value.ToString());
        }
    }
}