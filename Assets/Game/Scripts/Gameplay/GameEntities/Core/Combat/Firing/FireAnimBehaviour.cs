using Atomic.Elements;
using UnityEngine;

namespace Game
{
    public sealed class FireAnimBehaviour :
        IGameEntityInit,
        IGameEntityEnable,
        IGameEntityDisable
    {
        private static readonly int Attack = Animator.StringToHash(nameof(Attack));
        private ISignal _fireSignal;
        private Animator _animator;

        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
            _fireSignal = entity.GetFireEvent();
        }

        public void Enable(IGameEntity entity)
        {
            _fireSignal.Subscribe(OnFireSignal);
        }

        public void Disable(IGameEntity entity)
        {
            _fireSignal.Unsubscribe(OnFireSignal);
        }

        private void OnFireSignal()
        {
            _animator.SetTrigger(Attack);
        }
    }
}