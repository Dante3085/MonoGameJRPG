using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.States;

namespace MonoGameJRPG.General.Menus
{
    public class MainMenuState : State
    {
        private Menu _mainMenu;

        public MainMenuState(Menu mainMenu, SpriteBatch spriteBatch, Texture2D background, int backgroundWidth, int backgroundHeight) : base(spriteBatch, background, backgroundWidth, backgroundHeight)
        {
            _mainMenu = mainMenu;
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
            base.Render();
            _mainMenu.Render(_spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            _mainMenu.Update(gameTime);
        }
    }
}
