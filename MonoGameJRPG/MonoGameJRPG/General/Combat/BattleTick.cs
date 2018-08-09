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
    /// <summary>
    /// Responsible for ticking/updating Actions in combat until they're ready.
    /// If top Action is ready it will be passed to BattleExecute State and then removed from the List.
    /// </summary>
    public class BattleTick : State
    {
        private StateMachine _battleStates;
        private List<IAction> _actions;

        public BattleTick(StateMachine stateMachine, List<IAction> actions) :base(null, null, 0, 0)
        {
            _battleStates = stateMachine;
            _actions = actions;
        }

        public override void OnEnter()
        {
            throw new NotImplementedException();
        }
        public override void OnExit()
        {
            throw new NotImplementedException();
        }
        public override void Render()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (IAction a in _actions)
                a.Update(gameTime);

            if (_actions[0].IsReady())
            {
                // _battleStates.Change(EState.Execute, _actions[0]);
                _actions.RemoveAt(0);
            }
        }
    }
}
