using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.Characters;
using MonoGameJRPG.General.Combat;
using MonoGameJRPG.General.States;

namespace MonoGameJRPG.General.Combat
{
    /// <summary>
    /// Defines Combat in the game.
    /// </summary>
    public class BattleState : State
    {
        /// <summary>
        /// PlayerDecides and AIDecides are stored here.
        /// </summary>
        private List<IAction> _actions = new List<IAction>();

        /// <summary>
        /// Characters that participate in combat are stored in this List.
        /// </summary>
        private List<Character> _characters = new List<Character>();

        /// <summary>
        /// Handles States necessary for combat (BattleTick, BattleExecute)
        /// </summary>
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
            // Add States necessary for combat to StateMachine.

            _battleStates.Add(EState.BattleTick, new BattleTick(_battleStates, _actions));
            _battleStates.Add(EState.BattleExecute, new BattleExecute(_battleStates, _actions));
        }

        public override void OnEnter()
        {
            _battleStates.Change(EState.BattleTick);

            //
            // Get a decision action for every entity in the action queue
            // Then sort it so the quickest action is on top
            //

            foreach (Character c in _characters)
            {
                if (c.IsPlayerControlled)
                {
                    PlayerDecide action = new PlayerDecide(c);
                    _actions.Add(action);
                }
                else
                {
                    // AIDecide action = new AIDecide(c);
                    // _actions.Add(action);
                }
            }

            // SortDescending(_actions);
        }

        public override void OnExit()
        {
            throw new NotImplementedException();
        }

        public override void Render()
        {
            _battleStates.Render();
        }

        public override void Update(GameTime gameTime)
        {
            _battleStates.Update(gameTime);
        }
    }
}
