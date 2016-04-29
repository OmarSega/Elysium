using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Elysium
{
    /// <summary>
    /// Title: Elysium
    /// Description:
    ///   Final project for Object Oriented Programming
    /// </summary>
    // Scene management
    enum SceneManagement
    {
        LEVEL_1, LEVEL_2, MENU, EXIT
    };
    enum Stage
    {
        STAGE_1, STAGE_2, STAGE_3, STAGE_4, BOSS
    };
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu menu;
        Level1 level_1;
        SceneManagement selector;
        List<SoundEffect> SoundEffects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SoundEffects = new List<SoundEffect>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // GLOBAL CONFIGURATION
            graphics.PreferredBackBufferWidth = 1028;
            graphics.PreferredBackBufferHeight = 578;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            AbstractCharacter.SetLimits(1028, 578);
            selector = SceneManagement.MENU;

            // Menu
            menu = new Menu();

            // Scene initialization
            level_1 = new Level1();
            level_1.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Initialize and loop theme song
            SoundEffects.Add(Content.Load<SoundEffect>("theme.wav"));
            var instance = SoundEffects[0].CreateInstance();
            instance.IsLooped = true;
            instance.Volume = 0.2f;
            instance.Play();

            // Load scene content
            menu.LoadContent(Content);
            level_1.LoadContent(Content);
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
            if (selector == SceneManagement.MENU)
                selector = menu.Update();

            else if (selector == SceneManagement.LEVEL_1)
                selector = level_1.Update(gameTime, Content);

            else if (selector == SceneManagement.EXIT)
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(14, 14, 31));

            // TODO: Add your drawing code here;
            if (selector == SceneManagement.MENU)
                menu.Draw(spriteBatch);

            else if (selector == SceneManagement.LEVEL_1)
                level_1.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
