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
    public class BattleExecute : IState
    {
        private StateMachine _stateMachine;
        private Queue<IAction> _actions;

        public BattleExecute(StateMachine stateMachine, Queue<IAction> actions)
        {
            _stateMachine = stateMachine;
            _actions = actions;
        }

        public void OnEnter()
        {
            throw new NotImplementedException();
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
