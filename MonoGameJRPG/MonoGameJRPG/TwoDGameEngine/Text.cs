using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.Menus;
using MonoGameJRPG.TwoDGameEngine.Input;
using MonoGameJRPG.TwoDGameEngine.Utils;

namespace MonoGameJRPG.TwoDGameEngine
{
    public class Text : MenuElement
    {
        #region MemberVariables
        private string _text;
        private Rectangle _textRec;
        private SpriteFont _activeSpriteFont;
        private SpriteFont _spriteFontNoHover;
        private SpriteFont _spriteFontHover;
        private Vector2 _textSize;

        private int _x;
        private int _y;

        private bool _logValuesToConsole = false;
        #endregion

        #region Properties
        public override int X
        {
            get => _x;
            set => _x = value;
        }

        public override int Y
        {
            get => _y;
            set => _y = value;
        }

        public override int Width => _textRec.Width;
        public override int Height => _textRec.Height;
        #endregion

        public Text(SpriteFont spriteFontNoHover, SpriteFont spriteFontHover, string text = "", int x = 0, int y = 0)
        {
            _text = text;
            _spriteFontNoHover = spriteFontNoHover;
            _spriteFontHover = spriteFontHover;

            _activeSpriteFont = spriteFontNoHover;

            // MeasureString() returns a Vector2. Vector2.X is Width. Vector2.Y is Height. http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.graphics.spritefont_members.aspx
            _textSize = _activeSpriteFont.MeasureString(_text);
            _textRec = new Rectangle(x, y, (int)_textSize.X, (int)_textSize.Y);

            _x = x;
            _y = y;
        }

        public void SetText(string text)
        {
            _text = text;
        }

        public override void Update(GameTime gameTime)
        {
            _textSize = _activeSpriteFont.MeasureString(_text);

            // Update _textRec x,y, Position
            _textRec.X = (int)_x;
            _textRec.Y = (int)_y;

            // Update _textRec size.
            _textRec.Width = (int)_textSize.X;
            _textRec.Height = (int)_textSize.Y;

            if (_logValuesToConsole)
                Game1._gameConsole.Log("Text[" + _x + ", " + _y + ", " + _textSize.X + ", " + _textSize.Y
                                       + "], TextRec: " + _textRec.ToString());

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
            Util.DrawRectangle(spriteBatch, _textRec, new Rectangle[]
            {
                new Rectangle(),
                new Rectangle(),
                new Rectangle(),
                new Rectangle(), 
            }, Game1.recTex,Color.Red);
        }
    }
}
