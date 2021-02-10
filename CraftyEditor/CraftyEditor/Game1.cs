using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CraftyEditor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public const int width = 1400;
        public const int height = 800;

        public NodeUI test;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            test = new NodeUI(ref graphics, Content, "test");
            test.border = false;
            test.resize(ref graphics, 480, 480);
            test.x = 100;
            test.y = 100;

            //...

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //...
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            test.update(ref graphics, ref mouseState, 0);

            //...

            base.Update(gameTime);
        }

        private void Drawing()
        {
            test.render(ref spriteBatch);

            //...
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Drawing();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
