using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.TwoDGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.Menus.Layouts
{
    public class HBox<T> : MenuElement where T : MenuElement, ILocatable, IOrderable
    {
        private Vector2 _position;
        private float _horizontalOffset;
        private List<T> _elements = new List<T>();

        public HBox(Vector2 position, float horizontalOffset, params T[] elements)
        {
            _position = position;
            _horizontalOffset = horizontalOffset;

            if (elements != null)
                AddRange(elements);
        }

        /// <summary>
        /// Positions elements horizontally.
        /// Position of element is dependant on position of element in element list.
        /// </summary>
        private void OrderHorizontally()
        {
            // Position first element at upper left corner of VBox.
            _elements[0].X = _position.X;
            _elements[0].Y = _position.Y;

            // Position every element (except first) at VBox.Y and VBox.X + previousElement.X + horizontalOffset.
            // Makes it so that elements aren't stacked on top of each other and variable spacing is possible.
            for (int i = 1; i < _elements.Count; i++)
            {
                _elements[i].Y = _position.Y;
                _elements[i].X = _elements[i - 1].X + _elements[i - 1].Width;
            }
        }

        public void Add(T element)
        {
            _elements.Add(element);
        }

        public void AddRange(params T[] elements)
        {
            _elements.AddRange(elements);
            OrderHorizontally();
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
