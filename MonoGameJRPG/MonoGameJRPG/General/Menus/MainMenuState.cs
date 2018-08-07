using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameJRPG.General.States;
using MonoGameJRPG.TwoDGameEngine.Input;

namespace MonoGameJRPG.General.Menus
{
    public class MainMenuState : State, IState
    {
        private Menu _mainMenu;

        public MainMenuState(Menu mainMenu, SpriteBatch spriteBatch, Texture2D background, int backgroundWidth, int backgroundHeight) : base(spriteBatch, background, backgroundWidth, backgroundHeight)
        {
            _mainMenu = mainMenu;
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
            _mainMenu.Render(_spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            _mainMenu.Update(gameTime);
        }
    }
}
