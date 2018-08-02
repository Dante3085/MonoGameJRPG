using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.States
{
    public abstract class State
    {
        protected SpriteBatch _spriteBatch;
        protected Texture2D _background;
        protected Rectangle _backgroundRectangle;

        public State(SpriteBatch spriteBatch, Texture2D background, int backgroundWidth, int backgroundHeight)
        {
            _spriteBatch = spriteBatch;
            _background = background;
            _backgroundRectangle = new Rectangle(0, 0, backgroundWidth, backgroundHeight);
        }
    }
}
