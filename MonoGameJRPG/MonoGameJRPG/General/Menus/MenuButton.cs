using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.TwoDGameEngine;
using MonoGameJRPG.TwoDGameEngine.Input;
using System;

namespace MonoGameJRPG.General.Menus
{
    public class MenuButton : MenuElement, ILocatable, IOrderable
    {
        #region MemberVariables
        private Texture2D _buttonTextureNoHover;
        private Texture2D _buttonTextureHover;
        private Texture2D _activeButtonTexture;

        private Rectangle _buttonRec;

        private Action _buttonFunctionality;
        #endregion

        #region Properties
        public float X
        {
            get { return _buttonRec.X; }
            set { _buttonRec.X = (int)value; }
        }

        public float Y
        {
            get { return _buttonRec.Y; }
            set { _buttonRec.Y = (int)value; }
        }

        public int Width
        {
            get { return _buttonRec.Width; }
        }

        public int Height
        {
            get { return _buttonRec.Height; }
        }
        #endregion

        public MenuButton(Texture2D buttonTextureNoHover, Texture2D buttonTextureHover, int x = 0, int y = 0, Action function = null)
        {
            _buttonTextureNoHover = buttonTextureNoHover;
            _buttonTextureHover = buttonTextureHover;
            _buttonFunctionality = function;

            _activeButtonTexture = buttonTextureNoHover;

            _buttonRec = new Rectangle(x, y, _activeButtonTexture.Width, _activeButtonTexture.Height);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_activeButtonTexture, _buttonRec, Color.White);
        }

        public override void ExecuteFunctionality()
        {
            _buttonFunctionality();
        }

        /// <summary>
        /// Changes MenuButton's functionality to the given one.
        /// </summary>
        /// <param name="buttonFunctionality"></param>
        public override void ChangeFunctionality(Action functionality)
        {
            _buttonFunctionality = functionality;
        }

        public override void Update(GameTime gameTime)
        {
            OnMouseHoverReactions();

            if (OnLeftMouseClick())
                ExecuteFunctionality();
        }

        /// <summary>
        /// Handles Reactions that MenuButton will have on MouseHover.
        /// </summary>
        private void OnMouseHoverReactions()
        {
            if (IsMouseHover())
                _activeButtonTexture = _buttonTextureHover;
            else
                _activeButtonTexture = _buttonTextureNoHover;
        }

        /// <summary>
        /// Gets whether the Mouse is hovering this MenuButton.
        /// True if Mouse is hovering this MenuButton. Otherwise false.
        /// </summary>
        /// <returns></returns>
        public bool IsMouseHover()
        {
            return InputManager.IsMouseHoverRectangle(_buttonRec);
        }

        /// <summary>
        /// Gets whether the Mouse is clicking on this MenuButton.
        /// True if Mouse is clicking on this MenuButton. Otherwise false.
        /// </summary>
        /// <returns></returns>
        public bool OnLeftMouseClick()
        {
            return IsMouseHover() && InputManager.OnLeftMouseClick();
        }
    }
}
