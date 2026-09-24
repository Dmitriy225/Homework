using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public struct TransformReference : IComponentData
    {
        public TransformHandle Value;
    }
}