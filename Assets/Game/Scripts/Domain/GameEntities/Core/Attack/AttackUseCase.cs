using System;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SampleGame
{
    public static class AttackUseCase
    {
        public static float3 GetFirePoint(in LocalTransform transform, in AttackOffset attackOffset)
        {
            return transform.Position + math.rotate(transform.Rotation, attackOffset.Value);
        }
    }
}