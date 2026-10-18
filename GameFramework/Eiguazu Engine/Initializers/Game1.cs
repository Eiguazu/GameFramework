using GameFramework.Content.Engine;
using GameFramework.Content.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameFramework
{
    public class Game1 : Game
    {
        private AssetManager assetManager;
        private Engine _engine;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private DefaultGameObject DefaultGameObject;
        private Dictionary<string, Scene> sceneCache = new Dictionary<string, Scene>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            DefaultGameObject = new DefaultGameObject(new Vector2(0,0));
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            assetManager = new AssetManager(Content);
            Vector2 screenCenter = new Vector2(_graphics.PreferredBackBufferWidth / 2f, _graphics.PreferredBackBufferHeight / 2f);
            Scene.ScreenCenter = screenCenter;

            SetWindowSize(1280, 720);

            // ___________________________
            // Animation loading goes here
            // AssetManager.Instance.LoadAnimation("BloodSample", Sprites.BloodSample);
            // ---------------------------

            _engine = new Engine(BuildScene("Default"));

            // ___________________________
            // Dialouge loading goes here
            // DialogueLibrary.SetLine("NPC1-1", "Come see me when you have the blood sample and murder weapon.");
            // ---------------------------

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Input.Update();
            _engine.Update(gameTime);
            DefaultGameObject.Update(gameTime);

            string next = _engine.CurrentScene.NextScene;
            if (next != "")
            {
                _engine.CurrentScene.NextScene = "";
                _engine.ChangeScene(BuildScene(next));
            }

            base.Update(gameTime);
        }

        public void ResetBuildScene(string name) 
        {
            sceneCache.Remove(name);   
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw world objects with the camera.
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

            _engine.Draw(_spriteBatch, false);

            _spriteBatch.End();

            // Draw UI objects without the camera.
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _engine.Draw(_spriteBatch, true);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private Scene BuildScene(string name)
        {
            Scene scene = new DefaultScene();

            if (sceneCache.ContainsKey(name))
            {
                return sceneCache[name];
            }

            // Add new scenes here, they need to be registered here. 
            if (name == "___")
            {
                //scene = new ___();
            }
            else if (name == "___")
            {
                //scene = new ___();
            }
            else
            {
                scene = new DefaultScene();
            }
            sceneCache[name] = scene;
            return scene;
        }
        



        public void SetWindowSize(int width, int height)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;

            _graphics.ApplyChanges();
        }
    }
}
