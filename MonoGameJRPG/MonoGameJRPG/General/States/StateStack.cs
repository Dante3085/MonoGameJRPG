using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.States
{
    public class StateStack
    {
        Dictionary<EState, IState> _states;
        Stack<IState> _stack = new Stack<IState>();

        public StateStack(Dictionary<EState, IState> states)
        {
            _states = states;
        }

        public void Update(GameTime gameTime)
        {
            _stack.Peek().Update(gameTime);
        }

        public void Render()
        {
            _stack.Peek().Render();
        }

        public void Push(EState state)
        {
            if (_stack.Count != 0)
            {
                // Return if IState that is on top of Stack is IState to be pushed
                if (_stack.Peek().Equals(_states[state]))
                    return;
            }

            _stack.Push(_states[state]);
        }

        public IState Pop()
        {
            IState state = _stack.Pop();

            if (_stack.Count == 0)
                _stack.Push(state);

            return state;
        }
    }
}
