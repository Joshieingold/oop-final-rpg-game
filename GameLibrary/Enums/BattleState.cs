using System;
using System.Collections.Generic;
using System.Text;

namespace Core.State
{
    public enum BattleState
    {
        PlayerTurn,
        EnemyTurn,
        Victory,
        Defeat
    }
}
