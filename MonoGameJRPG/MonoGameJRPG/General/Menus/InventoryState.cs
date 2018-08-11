using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG.General.Characters;
using MonoGameJRPG.General.States;
using System;
using System.Collections.Generic;
using MonoGameJRPG.General.Menus.Layouts;
using MonoGameJRPG.TwoDGameEngine;

namespace MonoGameJRPG.General.Menus
{
    public class InventoryState : State
    {
        #region MemberVariables
        // TODO: Äußere Abhängigkeiten sollen übergeben werden, der Zusammenbau des Menüs soll aber hier gemacht werden.
        private Menu _inventoryMenu;
        // private VBox<CharacterInfo> _characterInfos;
        private VBox _options;
        private VBox _timeGil;
        private Text _currentLocation;
        private Text _time;
        private MenuButton _exitButton;

        private Action _exitBtnAction;

        private SpriteFont _fontNoHover;
        private SpriteFont _fontHover;

        private Texture2D[] _textures;
        #endregion

        #region Properties

        #endregion

        public InventoryState(SpriteFont fontNoHover, SpriteFont fontHover, SpriteBatch spriteBatch, Texture2D background, int backgroundWidth, int backgroundHeight, Action exitBtnAction,List<Character> characters = null, params Texture2D[] textures) : 
            base(spriteBatch, background, backgroundWidth, backgroundHeight, characters)
        {
            _exitBtnAction = exitBtnAction;

            _fontNoHover = fontNoHover;
            _fontHover = fontHover;

            _textures = textures;

            SetUpMenu();
        }

        public override void OnEnter()
        {
            throw new NotImplementedException();
        }

        public override void OnExit()
        {
            throw new NotImplementedException();
        }

        public override void Render()
        {                           
            base.Render();
            _inventoryMenu.Render(_spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            _inventoryMenu.Update(gameTime);
            _time.SetText(Game1._time.ToString());
        }

        private void SetUpMenu()
        {
            _exitButton = new MenuButton(_textures[0], _textures[1], 0, 0, function: _exitBtnAction);

            _options = new VBox(100, 0, 30, new MenuElement[]
            {
                new Text(_fontNoHover, _fontHover, "Item"),
                new Text(_fontNoHover, _fontHover, "Magic"),
                new Text(_fontNoHover, _fontHover, "Materia"),
                new Text(_fontNoHover, _fontHover, "Equip"),
                new Text(_fontNoHover, _fontHover, "Status"),
                new Text(_fontNoHover, _fontHover, "Order"),
                new Text(_fontNoHover, _fontHover, "Limit"),
                new Text(_fontNoHover, _fontHover, "Config"),
                new Text(_fontNoHover, _fontHover, "Save"),
            });

            _time = new Text(_fontNoHover, _fontHover, Game1._time.ToString());

            _timeGil = new VBox(300, 1000, 10, new Text[]
            {
                _time,
                new Text(_fontNoHover, _fontHover, "Gil: 0"),
            });

            _currentLocation = new Text(_fontNoHover, _fontHover, "Location: Map A", 1000, 100);

            _inventoryMenu = new Menu(new List<MenuElement>()
            {
                _exitButton, _options, _timeGil, _currentLocation
            });
        }
    }
}
