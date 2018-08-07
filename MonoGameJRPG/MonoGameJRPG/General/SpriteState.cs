using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.States;
using MonoGameJRPG.TwoDGameEngine.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General
{
    public class SpriteState : State, IState
    {
        private List<AnimatedSprite> _sprites;

        public SpriteState(List<AnimatedSprite> sprites, SpriteBatch spriteBatch, Texture2D background, int screenWidth, int screenHeight) : base(spriteBatch, background, screenWidth, screenHeight)
        {
            _sprites = sprites;
        }

        public void OnEnter()
        {
            // throw new NotImplementedException();
        }

        public void OnExit()
        {
            // throw new NotImplementedException();
        }

        public void Render()
        {
            foreach (AnimatedSprite a in _sprites)
                a.Draw(_spriteBatch, _sprites);
        }

        public void Update(GameTime gameTime)
        {
            foreach (AnimatedSprite a in _sprites)
                a.Update(gameTime);
        }
    }
}
