using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.States;

namespace MonoGameJRPG.General.Menu
{
    public class MainMenuState : State, IState
    {
        public MainMenuState(SpriteBatch spriteBatch, Texture2D background, int backgroundWidth, int backgroundHeight) : base(spriteBatch, background, backgroundWidth, backgroundHeight)
        {
            
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
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
