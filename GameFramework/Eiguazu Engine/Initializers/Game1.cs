using GameFramework.Content.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameFramework
{
    public class Game1 : Game
    {
        private AssetManager assetManager;
        private Engine _engine;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Main main;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            main = new Main();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            assetManager = new AssetManager(Content);

            Scene defaultScene = new Scene();
            _engine = new Engine(defaultScene);

            // ____________________________
            // Scene loading goes here
            // Default scene provided above
            // ----------------------------


            // ___________________________
            // Animation loading goes here
            // ---------------------------


            // ____________________________
            // GameObject loading goes here
            // ----------------------------
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _engine.Update(gameTime);
            main.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // For pixel art
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _engine.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetWindowSize(int width, int height)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;

            _graphics.ApplyChanges();
        }
    }
}
