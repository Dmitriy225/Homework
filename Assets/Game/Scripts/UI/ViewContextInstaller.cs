using Atomic.Entities;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public sealed class ViewContextInstaller : SceneEntityInstaller<IViewContext>
    {
        [SerializeField]
        private Joystick _moveJoystick;

        [SerializeField]
        private Joystick _attackJoystick;

        [SerializeField]
        private StatView _healthStatView;

        [SerializeField]
        private StatView _ammoStatView;

        [SerializeField]
        private TMP_Text _scoreText;

        [SerializeField]
        private GameEntity _character;

        public override void Install(IViewContext context)
        {
            var gameContext = GameContext.Instance;
            context.AddBehaviour(new MoveJoystickPresenter(_moveJoystick, gameContext));
            context.AddBehaviour(new AttackJoystickPresenter(_attackJoystick, gameContext));
            context.AddBehaviour(new HealthStatPresenter(_healthStatView, gameContext));
            context.AddBehaviour(new AmmoStatPresenter(_ammoStatView, gameContext));
            context.AddBehaviour(new ScorePresenter(_scoreText, gameContext));
        }
    }
}
