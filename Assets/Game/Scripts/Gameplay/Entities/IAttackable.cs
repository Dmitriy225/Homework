using System;

namespace Game
{
    public interface IAttackable
    {
        event Action OnDied;

        bool IsAlive { get; }

        void TakeDamage(int damage);
    }
}