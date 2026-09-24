using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct AnimatorReference : IComponentData
    {
        public UnityObjectRef<Animator> Value;
    }
}