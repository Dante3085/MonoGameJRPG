using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.Menus;
using MonoGameJRPG.TwoDGameEngine.Input;

namespace MonoGameJRPG.TwoDGameEngine
{
    public class Text : MenuElement, ILocatable, IOrderable
    {
        #region MemberVariables
        private string _text;
        private Rectangle _textRec;
        private SpriteFont _activeSpriteFont;
        private SpriteFont _spriteFontNoHover;
        private SpriteFont _spriteFontHover;

        private float _x;
        private float _y;
        #endregion

        #region Properties
        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }

        // MeasureString() returns a Vector2. Vector2.X is Width. Vector2.Y is Height. http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.graphics.spritefont_members.aspx
        public int Width => (int)_spriteFontNoHover.MeasureString(_text).X;
        public int Height => (int) _spriteFontNoHover.MeasureString(_text).Y;

        #endregion

        public Text(SpriteFont spriteFontNoHover, SpriteFont spriteFontHover, string text = "", float x = 0, float y = 0)
        {
            _text = text;
            _spriteFontNoHover = spriteFontNoHover;
            _spriteFontHover = spriteFontHover;

            _activeSpriteFont = spriteFontNoHover;

            _textRec = new Rectangle((int)x, (int)y, Width, Height);

            _x = x;
            _y = y;
        }

        public void SetText(string text)
        {
            _text = text;
        }

        public override void Update(GameTime gameTime)
        {
            _textRec.X = (int)_x;
            _textRec.Y = (int)_y;

            OnMouseHoverReactions();

            if (OnLeftMouseClick())
                ExecuteFunctionality();
        }

        public override void ExecuteFunctionality()
        {
            Game1._gameConsole.Log(_text + " wurde geklickt.");
        }

        public override void ChangeFunctionality(Action functionality)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles Reactions that MenuButton will have on MouseHover.
        /// </summary>
        private void OnMouseHoverReactions()
        {
            _activeSpriteFont = IsMouseHover() ? _spriteFontHover : _spriteFontNoHover;
        }

        /// <summary>
        /// Gets whether the Mouse is hovering this MenuButton.
        /// True if Mouse is hovering this MenuButton. Otherwise false.
        /// </summary>
        /// <returns></returns>
        public bool IsMouseHover()
        {
            return InputManager.IsMouseHoverRectangle(_textRec);
        }

        /// <summary>
        /// Gets whether the Mouse is clicking on this Text.
        /// True if Mouse is clicking on this Text. Otherwise false.
        /// </summary>
        /// <returns></returns>
        public bool OnLeftMouseClick()
        {
            return IsMouseHover() && InputManager.OnLeftMouseClick();
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_activeSpriteFont, _text, new Vector2(_x, _y), Color.Black);
        }
    }
}
