using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct RotationSpeed : IComponentData
    {
        public float Value;
    }
}