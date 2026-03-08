using System;
using UnityEngine;

namespace Game
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public event Action<TeamType> OnTeamChanged;

        public TeamType Team
        {
            get => _team;
        }

        [SerializeField]
        private TeamType _team;

        public void SetTeam(TeamType team)
        {
            if (_team == team)
            {
                return;
            }

            _team = team;
            OnTeamChanged?.Invoke(team);
        }
    }
}