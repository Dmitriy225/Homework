using Codice.CM.Common;
using System;
using UnityEngine;

namespace Game
{      
    public sealed class Bullet : MonoBehaviour, IMoveable
    {
        public struct BulletArgs
        {
            public float speed;
            public Vector2 direction;
            public int damage;
            public TeamType team;
        }

        public event Action<Vector2> OnMoved
        {
            add { _movementComponent.OnMoved += value; }
            remove { _movementComponent.OnMoved -= value; }
        }

        public event Action<Bullet> OnDied;
        public event Action OnHit;
        public event Action<TeamType> OnTeamChanged;

        public Vector2 MoveDirection
        {
            get => _movementComponent.Direction;
            set => _movementComponent.Direction = value;
        }

        public TeamType Team
        {
            get => _team;
        }

        [SerializeField]
        private MovementComponent _movementComponent;

        private int _damage;
        private TeamType _team;

        private void Awake()
        {
            _movementComponent.Construct(
                0,
                () => true
            );
        }

        public void SetArgs(BulletArgs args)
        {
            _movementComponent.Speed = args.speed;
            _movementComponent.Direction = args.direction;
            _damage = args.damage;
            SetTeam(args.team);
        }

        public void SetTeam(TeamType team)
        {
            if (_team == team)
            {
                return;
            }

            _team = team;
            OnTeamChanged?.Invoke(team);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IAttackable>(out var attackable))
            {
                if (other.TryGetComponent<ITeamer>(out var teamer))
                {
                    if (_team != teamer.Team)
                    {
                        OnHit?.Invoke();
                        attackable.TakeDamage(_damage);
                        OnDied?.Invoke(this);
                    }
                }
            }
        }
    }
}