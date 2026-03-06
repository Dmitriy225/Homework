using Modules.UI;
using UnityEngine;

namespace Game
{
    public sealed class ScorePresenter : MonoBehaviour
    {
        [SerializeField]
        private ScoreView _scoreView;

        [SerializeField]
        private EnemyManager _enemyManager;

        private void Awake()
        {
            _scoreView.SetValue(_enemyManager.DestroyedEnemies);
        }

        private void OnEnable()
        {
            _enemyManager.OnEnemyDestroyed += OnEnemyDestroyed;
        }


        private void OnDisable()
        {
            _enemyManager.OnEnemyDestroyed -= OnEnemyDestroyed;
        }

        private void OnEnemyDestroyed(int count)
        {
            _scoreView.SetValue(count);
        }
    }
}