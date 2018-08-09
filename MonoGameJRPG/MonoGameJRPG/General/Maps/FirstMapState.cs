using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameJRPG.General.Characters;
using MonoGameJRPG.General.Menus;
using MonoGameJRPG.General.States;
using MonoGameJRPG.TwoDGameEngine.Input;
using MonoGameJRPG.TwoDGameEngine.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.Maps
{
    public class FirstMapState : State
    {
        private Menu _mapMenu;

        public FirstMapState(Menu mapMenu, SpriteBatch spriteBatch, Texture2D background, int backgroundWidth, int backgroundHeight, List<Character> characters) : 
            base(spriteBatch, background, backgroundWidth, backgroundHeight, characters)
        {
            _mapMenu = mapMenu;
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

            _mapMenu.Render(_spriteBatch);
            foreach (Character c in _characters)
                c.AnimatedSprite.Draw(_spriteBatch, _characterSprites);
        }

        public override void Update(GameTime gameTime)
        {
            _mapMenu.Update(gameTime);

            if (_characters != null)
                foreach (Character c in _characters)
                    c.Update(gameTime, _characters);
        }

        #region HandleInput
        private void HandleKeyboardInput()
        {
            
        }
        #endregion
    }
}
