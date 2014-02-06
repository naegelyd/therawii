using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace TheraWii
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        DialogTask goodbye;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Therapy therapy;
        Profile profile;
        Session session;
        bool justWentFullScreen = false;

        Matrix worldMatrix;
        Matrix viewMatrix;
        Matrix projectionMatrix;
        BasicEffect basicEffect;
        VertexDeclaration vertexDeclaration;

        Line xAxis, yAxis;

        private const int PREFERRED_WIDTH = 1024;
        private const int PREFERRED_HEIGHT = 768;
		private const long defaultTargetElapsedTime = 333333; // 1/30th of a second in 100s of nanoseconds (ticks).;

        public Game(Therapy t, Profile p, bool fullscreen)
        {

            therapy = t;
            profile = p;
            session = new Session();            
			session.Initialize(profile, therapy);            
			profile.Sessions.Add(session);            
			graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = PREFERRED_WIDTH; // GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = PREFERRED_HEIGHT; // GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = fullscreen;
            InputDevice.GAME_WIDTH = graphics.PreferredBackBufferWidth;
            InputDevice.GAME_HEIGHT = graphics.PreferredBackBufferHeight;
			this.IsFixedTimeStep = true;
			this.TargetElapsedTime = new TimeSpan(defaultTargetElapsedTime);
            graphics.PreferMultiSampling = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            InitializeTransform();
            InitializeEffect();
            xAxis = new Line(GraphicsDevice, new Vector3(-1, 0, 0), new Vector3(1, 0, 0), Color.Gray);
            yAxis = new Line(GraphicsDevice, new Vector3(0, -1, 0), new Vector3(0, 1, 0), Color.Gray);
            Mouse.SetPosition(PREFERRED_WIDTH / 2, PREFERRED_HEIGHT / 2);
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
            therapy.tasks.Initialize(graphics, Content, spriteBatch, PREFERRED_WIDTH, PREFERRED_HEIGHT, session, Vector3.Zero);
            font = Content.Load<SpriteFont>("Fonts\\GameFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Initializes the transforms used by the game.
        /// </summary>
        private void InitializeTransform()
        {
            viewMatrix = Matrix.CreateLookAt(
                new Vector3(0.0f, 0.0f, 10.0f),
                Vector3.Zero,
                Vector3.Up
                );
            
            projectionMatrix = Matrix.CreatePerspective(
                0.2f,
                0.2f,
                1.0f, 1000.0f);
        }

        /// <summary>
        /// Initializes the effect (loading, parameter setting, and technique selection)
        /// used by the game.
        /// </summary>
        private void InitializeEffect()
        {
            vertexDeclaration = new VertexDeclaration(
                GraphicsDevice,
                VertexPositionColor.VertexElements
                );

            basicEffect = new BasicEffect(GraphicsDevice, null);
            basicEffect.VertexColorEnabled = true;

            worldMatrix = Matrix.Identity;
            basicEffect.World = worldMatrix;
            basicEffect.View = viewMatrix;
            basicEffect.Projection = projectionMatrix;
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
			WiiUse.Poll();

			// Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            // Toggle Full-screen with Alt-Enter
            KeyboardState keyState = Keyboard.GetState();
            if ((keyState.IsKeyDown(Keys.RightAlt) ||
                 keyState.IsKeyDown(Keys.LeftAlt)) &&
                 keyState.IsKeyDown(Keys.Enter))
            {
                if (!justWentFullScreen)
                {
                    graphics.ToggleFullScreen();
                    justWentFullScreen = true;
                }
            }
            else
            {
                justWentFullScreen = false;
            }
			// Do we exit
			if (therapy.tasks.isComplete() && goodbye == null)
            {
                goodbye = new DialogTask();
                goodbye.endCondition = new TimeLimitEndCondition();
                ((TimeLimitEndCondition)goodbye.endCondition).TimeLimit = (double)2.0;
                ((TimeLimitEndCondition)goodbye.endCondition).Type = TimeLimitType.TotalTime;
                goodbye.DisplayText = "Therapy Complete!";
                goodbye.Name = "Complete";
                goodbye.Initialize(this.graphics, this.Content, this.spriteBatch, PREFERRED_WIDTH, PREFERRED_HEIGHT, this.session, Vector3.Zero);
                goodbye.textBox.Initialize(goodbye.DisplayText, this.Content, this.spriteBatch, PREFERRED_WIDTH, PREFERRED_HEIGHT);
            }
            if (goodbye != null)
            {
                if (goodbye.isComplete())
                    this.Exit();
                else
                    goodbye.Update(gameTime);
            }
            else
            {
                // Update Current task
                therapy.tasks.Update(gameTime);
            }
			base.Update(gameTime);


        }

		protected override void OnExiting(object sender, EventArgs args)
		{
			base.OnExiting(sender, args);
			session.Finish();
			UnloadContent();
            graphics.GraphicsDevice.Dispose();
		}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.White);
            GraphicsDevice.VertexDeclaration = vertexDeclaration;

            basicEffect.Begin();
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Begin();

                xAxis.Draw();
                yAxis.Draw();

                if (!therapy.tasks.isComplete())
                    therapy.tasks.Draw(gameTime);
                else if (goodbye != null)
                    goodbye.Draw(gameTime);
                pass.End();
            }
            basicEffect.End();

            base.Draw(gameTime);
        }
    }
}
