using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.Menus;
using MonoGameJRPG.General.States;

namespace MonoGameJRPG.General
{
    public class GameState : State, IState
    {
        Menu _gameMenu;

        public GameState(Menu gameMenu, SpriteBatch spriteBatch, Texture2D background, int backgroundWidth, int backgroundHeight) : base(spriteBatch, background, backgroundWidth, backgroundHeight)
        {
            _gameMenu = gameMenu;
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
            _spriteBatch.Draw(_background, _backgroundRectangle, Color.White);
            _gameMenu.Render(_spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            _gameMenu.Update(gameTime);
        }
    }
}
