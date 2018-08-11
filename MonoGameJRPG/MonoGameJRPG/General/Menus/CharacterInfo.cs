using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.Characters;

namespace MonoGameJRPG.General.Menus
{
    /// <summary>
    /// Displays a Character's Info visually.
    /// </summary>
    public class CharacterInfo : MenuElement
    {
        #region MemberVariables
        private Character _character;

        private Rectangle _rec;
        // private Image _charImage;
        #endregion

        #region Properties
        public override int Width { get; }
        public override int Height { get; }
        public override int X { get; set; }
        public override int Y { get; set; }
        #endregion

        public CharacterInfo(Character character)
        {
            _character = character;
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteFunctionality()
        {
            throw new NotImplementedException();
        }

        public override void ChangeFunctionality(Action functionality)
        {
            throw new NotImplementedException();
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
