using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.Characters;
using MonoGameJRPG.General.Combat;
using MonoGameJRPG.General.States;

namespace MonoGameJRPG.General.Combat
{
    public class BattleState : State, IState
    {
        private Queue<IAction> _actions = new Queue<IAction>();
        private List<ICombatEntity> _characters = new List<Character>();

        private StateMachine _battleStates = new StateMachine();

        #region StaticMethods
        // TODO: C# "Method" to sort List of T. Comparable, Comparator etc.
        //public static bool SortByTime(CombatAction a, CombatAction b)
        //{
        //    return a.TimeRemaining() > b.TimeRemaining();
        //}
        #endregion

        public BattleState(SpriteBatch spriteBatch, Texture2D background, int backgroundWidth, int backgroundHeight) : base(spriteBatch, background, backgroundWidth, backgroundHeight)
        {
            _battleStates.Add(EState.Tick, new BattleTick(_battleStates, _actions));
            _battleStates.Add(EState.Execute, new BattleExecute(_battleStates, _actions));
        }

        public void OnEnter()
        {
            _battleStates.Change(EState.Tick);

            //
            // Get a decision action for every entity in the action queue
            // The sort it so the quickest actions are the top
            //

            foreach (Character c in _characters)
            {
                if (c.IsPlayerControlled)
                {
                    PlayerDecide action = new PlayerDecide(c, c.speed());
                    _actions.Add(action);
                }
                else
                {
                    AIDecide action = new AIDecide(c, c.Speed());
                    _actions.Add(action);
                }
            }

            Sort(_actions, BattleState.SortByTime());
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            _battleStates.Render();
        }

        public void Update(GameTime gameTime)
        {
            _battleStates.Update(gameTime);
        }
    }
}
