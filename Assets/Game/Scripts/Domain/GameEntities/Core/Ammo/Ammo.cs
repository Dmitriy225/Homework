using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct Ammo : IComponentData
    {
        public int Value;
    }
}