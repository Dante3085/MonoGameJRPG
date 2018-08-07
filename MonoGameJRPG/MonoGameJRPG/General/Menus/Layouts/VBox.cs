using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.TwoDGameEngine;
using System;
using System.Collections.Generic;

namespace MonoGameJRPG.General.Menus.Layouts
{
    public class VBox<T> : MenuElement where T : MenuElement, ILocatable, IOrderable
    {
        private Vector2 _position;
        private float _verticalOffset;
        private List<T> _elements = new List<T>();

        public VBox(Vector2 position, float verticalOffset = 0, params T[] elements)
        {
            _position = position;
            _verticalOffset = verticalOffset;

            if (elements != null)
                AddRange(elements);
        }

        /// <summary>
        /// Orders elements vertically.
        /// Position of element is dependant on position of element in element list.
        /// </summary>
        private void OrderVertically()
        {
            // Position first element at upper left corner of VBox.
            _elements[0].X = _position.X;
            _elements[0].Y = _position.Y;

            // Position every element (except first) at VBox.X and VBox.Y + previousElement.Y + verticalOffset.
            // Makes it so that elements aren't stacked on top of each other and variables spacing is possible.
            for (int i = 1; i < _elements.Count; i++)
            {
                _elements[i].X = _position.X;
                _elements[i].Y = _elements[i - 1].Y + _elements[i - 1].Height;
            }
        }

        public void Add(T element)
        {
            _elements.Add(element);
        }

        public void AddRange(params T[] elements)
        {
            _elements.AddRange(elements);
            OrderVertically();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (T t in _elements)
                t.Update(gameTime);
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
            foreach (T t in _elements)
                t.Render(spriteBatch);
        }
    }
}
