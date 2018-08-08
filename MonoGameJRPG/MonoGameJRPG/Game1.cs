using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameJRPG.General;
using MonoGameJRPG.General.Menus;
using MonoGameJRPG.General.Menus.Layouts;
using MonoGameJRPG.General.States;
using MonoGameJRPG.TwoDGameEngine.Input;
using MonoGameJRPG.TwoDGameEngine.Sprite;
using System.Collections.Generic;
using VosSoft.Xna.GameConsole;

namespace MonoGameJRPG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static GameConsole gameConsole;

        private StateStack _stateStack;

        private int screenWidth;
        private int screenHeight;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferWidth = 3240;
            //graphics.PreferredBackBufferHeight = 2160;

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;

            graphics.IsFullScreen = true;

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
            gameConsole = new GameConsole(this, "german", Content);
            gameConsole.IsFullscreen = true;

            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeight = graphics.PreferredBackBufferHeight;

            base.Initialize();
        }

        #region ButtonFunctionalityMethods
        private void PushGameState()
        {
            _stateStack.Push(EState.GameState);
        }

        public void PopStateStack()
        {
            _stateStack.Pop();
        }

        public void SayHiInConsole()
        {
            gameConsole.Log("Hi");
        }
        #endregion

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D mainMenuBackground = Content.Load<Texture2D>("DeusExMainMenu");
            Texture2D gameBackground = Content.Load<Texture2D>("Space");
            Texture2D playerSheet = Content.Load<Texture2D>("playerSheet");
            Texture2D btnNoHover = Content.Load<Texture2D>("btnNoHover");
            Texture2D btnHover = Content.Load<Texture2D>("btnHover");

            MenuButton button1 = new MenuButton(btnNoHover, btnHover, function: PushGameState);
            MenuButton button2 = new MenuButton(btnNoHover, btnHover, function: PushGameState);
            MenuButton button3 = new MenuButton(btnNoHover, btnHover, function: PushGameState);
            MenuButton button4 = new MenuButton(btnNoHover, btnHover, function: PushGameState);
            VBox<MenuButton> vbox = new VBox<MenuButton>(Vector2.Zero, 5, button1, button2, button3, button4 );

            Menu mainMenu = new Menu(new List<MenuElement>()
            {
                vbox
            });

            Menu gameMenu = new Menu(new List<MenuElement>()
            {
                new HBox<MenuButton>(Vector2.Zero, 0, new MenuButton[]
                {
                    new MenuButton(btnNoHover, btnHover, function: PopStateStack),
                    new MenuButton(btnNoHover, btnHover, function: SayHiInConsole)
                }),
            });

            AnimatedSprite player1 = new AnimatedSprite("Player1", new Vector2(100, 100), PlayerIndex.One, GraphicsDevice, playerSheet, new KeyboardInput()
            {
                Left = Keys.A,
                Up = Keys.W,
                Right = Keys.D,
                Down = Keys.S
            });
            AnimatedSprite player2 = new AnimatedSprite("Player2", new Vector2(200, 100), PlayerIndex.Two, GraphicsDevice, playerSheet, new KeyboardInput()
            {
                Left = Keys.Left,
                Up = Keys.Up,
                Right = Keys.Right,
                Down = Keys.Down
            });

            List<AnimatedSprite> sprites = new List<AnimatedSprite>();
            sprites.Add(player1);
            sprites.Add(player2);

            _stateStack = new StateStack(new Dictionary<EState, IState>()
            {
                { EState.MainMenu, new MainMenuState(mainMenu, spriteBatch, mainMenuBackground, screenWidth, screenHeight) },
                { EState.GameState, new GameState(gameMenu, spriteBatch, gameBackground, screenWidth, screenHeight) },
                { EState.SpriteState, new SpriteState(sprites, spriteBatch, gameBackground, screenWidth, screenHeight)}

            });

            _stateStack.Push(EState.MainMenu);
            _stateStack.Push(EState.GameState);
            _stateStack.Push(EState.SpriteState);

            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            InputManager.UpdateCurrentStates();

            if (InputManager.OnKeyDown(Keys.F1))
                _stateStack.Pop();
            else if (InputManager.OnKeyDown(Keys.F2))
                _stateStack.Push(EState.GameState);
            else if (InputManager.OnKeyDown(Keys.F3))
                _stateStack.Push(EState.SpriteState);

            if (InputManager.OnKeyDown(Keys.Tab))
                gameConsole.Open(Keys.Tab);

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
            spriteBatch.Begin();

            _stateStack.Render();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
