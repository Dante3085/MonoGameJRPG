﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGameJRPG.General.Menus.Layouts
{
    public class VBox : Layout
    {
        #region MemberVariables
        private int _x;
        private int _y;
        private int _verticalOffset;
        private List<MenuElement> _elements = new List<MenuElement>();
        #endregion

        #region Properties
        public override int Width => WidthWidestElement();
        public override int Height => HeightTallestElement();
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
        public override int Offset
        {
            get => _verticalOffset;
            set => _verticalOffset = value;
        }
        #endregion

        public VBox(int x = 0, int y = 0, int verticalOffset = 0, params MenuElement[] elements)
        {
            _x = x;
            _y = y;
            _verticalOffset = verticalOffset;

            if (elements != null)
            {
                _elements.AddRange(elements);
                OrderVertically();
            }
            else
            {
                _elements = new List<MenuElement>();
            }
        }

        private int HeightTallestElement()
        {
            int height = _elements[0].Height;

            foreach(MenuElement m in _elements)
                if (m.Height > height)
                    height = m.Height;
            return height;
        }

        private int WidthWidestElement()
        {
            int width = _elements[0].Width;

            foreach (MenuElement m in _elements)
                if (m.Width > width)
                    width = m.Width;
            return width;
        }

        /// <summary>
        /// Orders elements vertically.
        /// Position of element is dependant on position of element in element list.
        /// </summary>
        private void OrderVertically()
        {
            // Position first element at upper left corner of VBox.
            _elements[0].X = this._x;
            _elements[0].Y = this._y;

            // Position every element (except first) at VBox.X and VBox.Y + previousElement.Y + verticalOffset.
            // Makes it so that elements aren't stacked on top of each other and variables spacing is possible.
            for (int i = 1; i < _elements.Count; i++)
            {
                _elements[i].X = this._x;
                _elements[i].Y = _elements[i - 1].Y + _elements[i - 1].Height + _verticalOffset;
            }
        }

        public override List<MenuElement> Elements()
        {
            return _elements;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (MenuElement m in _elements)
                m.Update(gameTime);
            OrderVertically();
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
            foreach (MenuElement m in _elements)
                m.Render(spriteBatch);
        }
    }
}
