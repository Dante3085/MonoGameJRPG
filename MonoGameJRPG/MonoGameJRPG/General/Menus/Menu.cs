using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

// TODO: VBox, HBox etc as Menu Functions.

namespace MonoGameJRPG.General.Menus
{
    /// <summary>
    /// Organizes MenuElements.
    /// </summary>
    ///  TODO: Was ist der Sinn dieser Klasse ?
    public class Menu
    {
        private List<MenuElement> _menuElements;

        public Menu(List<MenuElement> menuElements = null)
        {
            _menuElements = menuElements;

            if (_menuElements == null)
                _menuElements = new List<MenuElement>();
        }

        /// <summary>
        /// Draws all MenuElements on screen.
        /// </summary>
        public void Render(SpriteBatch spriteBatch)
        {
            foreach (MenuElement m in _menuElements)
                m.Render(spriteBatch);
        }

        /// <summary>
        /// Updates all MenuElements.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            foreach (MenuElement m in _menuElements)
                m.Update(gameTime);
        }

        /// <summary>
        /// Adds the given MenuElement to the Menu.
        /// </summary>
        /// <param name="menuElement"></param>
        public void Add(MenuElement menuElement)
        {
            _menuElements.Add(menuElement);
        }
    }
}
