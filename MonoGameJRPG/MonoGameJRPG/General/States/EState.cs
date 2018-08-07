using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.States
{
    public enum EState
    {
        MainMenu,
        GameState,
        SpriteState,

        #region Combat
        Tick,
        Execute
        #endregion
    }
}
