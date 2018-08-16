using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.Characters;
using MonoGameJRPG.General.Menus.Layouts;
using MonoGameJRPG.TwoDGameEngine;

namespace MonoGameJRPG.General.Menus
{
    /// <summary>
    /// Displays a Character's Info visually.
    /// Essentially a small hierarchy of layouts with Texts.
    /// </summary>
    public class CharacterInfo : MenuElement
    {
        #region MemberVariables
        private Character _character;
        private Text _name;
        private Text _lvl;
        private Text _hp;
        private Text _mp;
        private Text _nextLvl;
        private Text _limitLvl;
        // private Image _charImage;

        private HBox _hBox;
        private VBox _firstRow;
        private VBox _secondRow;

        private Action _functionality;
        #endregion

        #region Properties
        public override int Width { get => _hBox.Width; }
        public override int Height { get => _hBox.Height; }
        public override int X { get => _hBox.X; set => _hBox.X = value; }
        public override int Y { get => _hBox.Y; set => _hBox.Y = value; }

        #endregion

        public CharacterInfo(Character character, Action functionality = null)
        {
            _character = character;

            _name = new Text(Game1.fontNoHover, Game1.fontHover, _character.Name);
            _lvl = new Text(Game1.fontNoHover, Game1.fontHover, "Lvl " + _character.Lvl);
            _hp = new Text(Game1.fontNoHover, Game1.fontHover, "Hp " + _character.CurrentHp + "/" + _character.MaxHp);
            _mp = new Text(Game1.fontNoHover, Game1.fontHover, "Mp " + _character.CurrentMp + "/" + _character.MaxMp);
            _nextLvl = new Text(Game1.fontNoHover, Game1.fontHover, "NextLvl ");
            _limitLvl = new Text(Game1.fontNoHover, Game1.fontHover, "LimitLvl ");

            _firstRow = new VBox(elements: new MenuElement[]
            {
                _name,
                _lvl,
                _hp,
                _mp
            });

            _secondRow = new VBox(elements: new MenuElement[]
            {
                _nextLvl,
                _limitLvl
            });

            _hBox = new HBox(horizontalOffset: 30, elements: new MenuElement[]
            {
                /*_image,*/ _firstRow, _secondRow
            }, functionality: functionality);
        }

        public override void Update(GameTime gameTime)
        {
            _hBox.Update(gameTime);
        }

        public override void ExecuteFunctionality()
        {
            _hBox.ExecuteFunctionality();
        }

        public override void ChangeFunctionality(Action functionality)
        {
            _hBox.ChangeFunctionality(functionality);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            _hBox.Render(spriteBatch);
        }
    }
}
