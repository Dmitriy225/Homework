using System;
using UnityEngine;

namespace Game
{      
    public sealed class Bullet : MonoBehaviour
    {
        public struct Args
        {
            public float speed;
            public Vector2 direction;
            public int damage;
            public TeamType team;
        }

        public event Action<Bullet> OnDied;
        public event Action OnHit;

        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private TeamComponent _teamComponent;

        private int _damage;

        private void Awake()
        {
            _movementComponent.Construct(
                0,
                () => true
            );
        }

        public void SetArgs(Args args)
        {
            _movementComponent.Speed = args.speed;
            _movementComponent.Direction = args.direction;
            _damage = args.damage;
            _teamComponent.SetTeam(args.team);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<HealthComponent>(out var attackable))
            {
                if (other.TryGetComponent<TeamComponent>(out var teamer))
                {
                    if (_teamComponent.Team != teamer.Team)
                    {
                        OnHit?.Invoke();
                        attackable.Reduce(_damage);
                        OnDied?.Invoke(this);
                    }
                }
            }
        }
    }
}