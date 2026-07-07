using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

/**
 * Created by Entity Domain Generator.
 */

namespace Game
{
    /// <summary>
    /// A Unity <see cref="MonoBehaviour"/> that can be attached to a GameObject to perform installation logic on an <see cref="IPlayerContext"/> during runtime or initialization.
    /// </summary>
    /// <remarks>
    /// Used to declaratively configure entities placed in a scene.
    /// In the Editor, it supports automatic refresh via <c>OnValidate</c>.
    /// </remarks>
    public sealed class PlayerContextInstaller : SceneEntityInstaller<IPlayerContext>
    {
        [SerializeField]
        private Const<SceneEntity> _character;

        public override void Install(IPlayerContext context)
        {
            context.AddCharacter(_character);
            context.AddBehaviour<CharacterInputBehaviour>();
        }
    }
}
