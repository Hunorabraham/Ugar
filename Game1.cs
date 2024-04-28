using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Ugar
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        static public List<Image> RenderList = new();
        static public Dictionary<string, Texture2D> TextureList = new();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.ToggleFullScreen();
            _graphics.PreferredBackBufferWidth = (int)Tool.ScreenScale.X;
            _graphics.PreferredBackBufferHeight = (int)Tool.ScreenScale.Y;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MenuManager.LoadAll(Content);
            MenuManager.LoadMainMenu();
        }

        protected override void Update(GameTime gameTime)
        {
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            foreach (var item in RenderList)
            {
                _spriteBatch.Draw(item.Texture,item.Position,null,Color.Gray,0f,item.Position/2f,item.Scale,SpriteEffects.None,item.LayerDepth);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
