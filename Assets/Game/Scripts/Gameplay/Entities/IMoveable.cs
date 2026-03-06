using System;
using UnityEngine;

namespace Game
{
    public interface IMoveable
    {
        event Action<Vector2> OnMoved;

        Vector2 MoveDirection { get; set; }
    }
}