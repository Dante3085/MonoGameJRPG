﻿using Microsoft.Xna.Framework;
using MonoGameJRPG.General.Characters;
using MonoGameJRPG.General.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.Combat
{
    /// <summary>
    /// Responsible for 
    /// </summary>
    public class BattleExecute : IState
    {
        private StateMachine _battleStates;
        private List<IAction> _actions;

        public BattleExecute(StateMachine stateMachine, List<IAction> actions)
        {
            _battleStates = stateMachine;
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
            // Play Animations

            // On AnimationSignal: DoBattleCalcualtions
            _actions[0].ExecuteAction();
        }
    }
}
