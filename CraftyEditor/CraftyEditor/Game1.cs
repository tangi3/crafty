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

        public const int screen_width = 1400;
        public const int screen_height = 800;

        UIManager ui = new UIManager(screen_width, screen_height);

        Tileset tileset = new Tileset(0, 240, 240, 32);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = screen_width;
            graphics.PreferredBackBufferHeight = screen_height;
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            ui.color = Color.DarkCyan;
            //ui.containers.Add(0, new Container(0, 0, 0, 240, 240));
            //...

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tileset.loadFromPipeline(Content, "Tilesets/test");
        }

        private void Drawing()
        {
            ui.RenderSelf(graphics.GraphicsDevice, spriteBatch);

            tileset.Draw(ref spriteBatch, 240, 240);

            //...

            ui.RenderUI(graphics.GraphicsDevice, spriteBatch);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ui.UpdateUI();

            //...

            base.Update(gameTime);
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
