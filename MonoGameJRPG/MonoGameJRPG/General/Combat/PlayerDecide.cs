using Microsoft.Xna.Framework;
using MonoGameJRPG.General.Characters;
using MonoGameJRPG.General.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.Combat
{
    public class PlayerDecide : IAction
    {
        private Character _owner;
        private StateMachine _battleStates;

        public PlayerDecide(Character owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ChooseAction()
        {

        }

        public void ExecuteAction()
        {
            // _owner.
        }

        public bool IsReady()
        {
            throw new NotImplementedException();
        }

        public int TimeRemaining()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
