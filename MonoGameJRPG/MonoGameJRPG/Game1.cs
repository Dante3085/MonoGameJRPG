using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameJRPG.General;
using MonoGameJRPG.General.Characters;
using MonoGameJRPG.General.Maps;
using MonoGameJRPG.General.Menus;
using MonoGameJRPG.General.Menus.Layouts;
using MonoGameJRPG.General.States;
using MonoGameJRPG.TwoDGameEngine.Input;
using MonoGameJRPG.TwoDGameEngine.Sprite;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework.Content;
using MonoGameJRPG.TwoDGameEngine.Utils;
using VosSoft.Xna.GameConsole;

namespace MonoGameJRPG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static Time _time;
        public static GameConsole _gameConsole;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Screen Width and Height
        private int _screenWidth;
        private int _screenHeight;

        /// <summary>
        /// Controls states of this game.
        /// </summary>
        private StateStack _stateStack;



        #region Ressources
        public static Texture2D recTex;
        public static Texture2D mainMenuBackground;
        public static Texture2D firstMapBackground;
        public static Texture2D playerSheet;
        public static Texture2D btnNoHover;
        public static Texture2D btnHover;
        public static Texture2D inventoryBackground;

        public static SpriteFont fontNoHover;
        public static SpriteFont fontHover;

        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            _graphics.IsFullScreen = true;

            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _time = new Time();

            _gameConsole = new GameConsole(this, "german", Content);
            _gameConsole.IsFullscreen = true;

            _screenWidth = _graphics.PreferredBackBufferWidth;
            _screenHeight = _graphics.PreferredBackBufferHeight;

            base.Initialize();
        }

        #region ButtonFunctionalityMethods
        private void QuitGame()
        {
            Exit();
        }

        private void StateStackPush_FirstMapState()
        {
            _stateStack.Push(EState.FirstMapState);
        }

        private void StateStackPush_InventoryState()
        {
            _stateStack.Push(EState.InventoryState);
        }

        private void StateStackPop()
        {
            _stateStack.Pop();
        }
        #endregion

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            mainMenuBackground = Content.Load<Texture2D>("Space");
            firstMapBackground = Content.Load<Texture2D>("samurai");
            playerSheet = Content.Load<Texture2D>("playerSheet");
            btnNoHover = Content.Load<Texture2D>("btnNoHover");
            btnHover = Content.Load<Texture2D>("btnHover");
            inventoryBackground = Content.Load<Texture2D>("blueBackground");

            recTex = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            recTex.SetData(new[] { Color.White });

            fontNoHover = Content.Load<SpriteFont>("FontNoHover");
            fontHover = Content.Load<SpriteFont>("FontHover");

            Menu mainMenu = new Menu(new List<MenuElement>()
            {
                new VBox(0, 0, 10, elements: new MenuButton[]
                {
                    new MenuButton(btnNoHover, btnHover, function: StateStackPush_FirstMapState),
                    new MenuButton(btnNoHover, btnHover, function: QuitGame)
                })
            });
            Menu mapMenu = new Menu(new List<MenuElement>()
            {
                new VBox(0, 0, 0, elements: new MenuButton[]
                {
                    new MenuButton(btnNoHover, btnHover, function: StateStackPush_InventoryState), 
                    new MenuButton(btnNoHover, btnHover, function: StateStackPop),
                })
            });
            Menu inventoryMenu = new Menu(new List<MenuElement>()
            {
                new MenuButton(btnNoHover, btnHover, function: StateStackPop),
            });

            List<Character> characters = new List<Character>()
            {
                new Character("Player 1", 1000, 99, 10, 10, 10, 10, 10, true, new KeyboardInput()
                {
                    Left = Keys.A,
                    Up = Keys.W,
                    Right = Keys.D,
                    Down = Keys.S
                }, animatedSprite: new AnimatedSprite("Player 1 Sprite", new Vector2(300, 300), PlayerIndex.One, GraphicsDevice, playerSheet)),

                new Character("Player 2", 200, 700, 10, 10, 10, 10, 10, true, new KeyboardInput()
                {
                    Left = Keys.Left,
                    Up = Keys.Up,
                    Right = Keys.Right,
                    Down = Keys.Down
                }, animatedSprite: new AnimatedSprite("Player 2 Sprite", new Vector2(400, 300), PlayerIndex.Two, GraphicsDevice, playerSheet))
            };

            _stateStack = new StateStack(new Dictionary<EState, State>()
            {
                { EState.MainMenuState, new MainMenuState(mainMenu, _spriteBatch, mainMenuBackground, _screenWidth, _screenHeight)},
                { EState.FirstMapState, new FirstMapState(mapMenu, _spriteBatch, firstMapBackground, _screenWidth, _screenHeight, characters) },
                { EState.InventoryState, new InventoryState(fontNoHover, fontHover, _spriteBatch, inventoryBackground, _screenWidth, _screenHeight, 
                    StateStackPop, textures: new Texture2D[]{btnNoHover, btnHover}, characters: characters) }
            });

            _stateStack.Push(EState.MainMenuState);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _time.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            InputManager.UpdateCurrentStates();

            if (InputManager.OnKeyDown(Keys.Tab))
                _gameConsole.Open(Keys.Tab);

            _stateStack.Update(gameTime);

            InputManager.UpdatePreviousStates();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _stateStack.Render();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
