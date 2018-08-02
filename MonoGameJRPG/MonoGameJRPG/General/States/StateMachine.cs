using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.States
{
    public class StateMachine
    {
        Dictionary<EState, IState> _states = new Dictionary<EState, IState>();
        IState _currentState = new EmptyState();

        public void Update(GameTime gameTime)
        {
            _currentState.Update(gameTime);
        }

        public void Render()
        {
            _currentState.Render();
        }

        public void Change(EState state /*, params*/)
        {
            _currentState.OnExit();
            _currentState = _states[state];
            _currentState.OnEnter(/*params*/);
        }

        public void Add(EState stateName, IState state)
        {
            _states[stateName] = state;
        }
    }
}
