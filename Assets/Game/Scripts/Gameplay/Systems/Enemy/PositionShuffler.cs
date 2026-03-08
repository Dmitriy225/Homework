using Modules.Utils;
using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class PositionShuffler
    {
        [SerializeField]
        private Transform[] _positions;

        private int _index;

        public void Shuffle()
        {
            _positions.Shuffle();
        }

        public Vector3 NextPosition()
        {
            if (_index >= _positions.Length)
            {
                _positions.Shuffle();
                _index = 0;
            }

            return _positions[_index++].position;
        }
    }
}