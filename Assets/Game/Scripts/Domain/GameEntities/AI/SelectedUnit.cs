using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct SelectedUnit : IComponentData
    {
        public FixedString64Bytes Name;
    }
}