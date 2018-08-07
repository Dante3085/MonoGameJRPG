using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.Characters
{
    /// <summary>
    /// Defines an Action in Battle/Combat
    /// Decision about next Action, Attack, Magic and Item are Actions.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Returns true if Action is ready to execute. If Action still needs to tick, false.
        /// </summary>
        /// <returns></returns>
        bool IsReady();

        /// <summary>
        /// Returns time that Action needs until it can be executed.
        /// </summary>
        /// <returns></returns>
        int TimeRemaining();

        /// <summary>
        /// Does updates Action needs every tick. E.g. updating timeRemaining.
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Executes Action.
        /// </summary>
        void ExecuteAction();
    }
}
