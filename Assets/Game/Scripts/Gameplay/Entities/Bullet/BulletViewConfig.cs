using System;
using UnityEngine;

namespace Game
{
    // +
    [CreateAssetMenu(
        fileName = "BulletViewConfig",
        menuName = "Game/Configs/View/New BulletViewConfig"
    )]
    public sealed class BulletViewConfig : ScriptableObject
    {
        [Serializable]
        public struct TeamVfxData
        {
            public TeamType team;
            public ParticleSystem particle;
        }

        [field: SerializeField]
        public GameObject ExplosionVFX  { get; private set; }

        [SerializeField]
        private TeamVfxData[] _vfxPrefabs;

        public ParticleSystem GetVfxPrefabOrDefault(TeamType team)
        {
            for (int i = 0; i < _vfxPrefabs.Length; i++)
            {
                if (_vfxPrefabs[i].team == team)
                {
                    return _vfxPrefabs[i].particle;
                }
            }

            return default;
        }
    }
}