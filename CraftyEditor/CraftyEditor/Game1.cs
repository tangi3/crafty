using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CraftyEditor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int width = 1400;
        public const int height = 800;
        
        Node2D test;
        Node2D test2;

        //...

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
            
            test = new Node2D(graphics);
            test.resize(graphics, 100, 100);
            test.position.X = 100;
            test.position.Y = 10;
            test.color = Color.DarkRed;

            test2 = new Node2D(graphics);
            test2.resize(graphics, 300, 120);
            test2.position.X = 300;
            test2.position.Y = 100;
            test.color = Color.DarkBlue;

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

            test.update(ref mouseState);
            test2.update(ref mouseState);

            //...

            base.Update(gameTime);
        }

        private void Drawing()
        {
            test.draw(ref spriteBatch);
            test2.draw(ref spriteBatch);

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
