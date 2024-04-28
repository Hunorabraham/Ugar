using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Ugar
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        static public List<Image> RenderList = new();
        static public Dictionary<string, Texture2D> TextureList = new();
        static public Button LETMEOUT;
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
            LETMEOUT = new Button(0.86f, 0.88f, 0.23f, 0.08f, () => { Exit(); return 0;});
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

            //update mousePosition
            MouseState CurrentState = Mouse.GetState();
            Tool.MousePosition = CurrentState.Position.ToVector2() / Tool.ScreenScale;


            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin();

            //render the cursor
            _spriteBatch.Draw(TextureList["DebugTexture0"], Tool.MousePosition * Tool.ScreenScale, null, Color.Orange, 0f, new Vector2(50, 50), 10 / 100 * Tool.ScreenScale, SpriteEffects.None, 1);
            // TODO: Add your drawing code here
            foreach (var item in RenderList)
            {
                _spriteBatch.Draw(item.Texture,item.Position*Tool.ScreenScale,null,Color.Gray,0f,new Vector2(item.Texture.Width/2f,item.Texture.Height/2f),(new Vector2(item.Scale.X/item.Texture.Width,item.Scale.Y/item.Texture.Height))*Tool.ScreenScale,SpriteEffects.None,item.LayerDepth);
            }
            _spriteBatch.Draw(TextureList["DebugTexture0"],LETMEOUT.Position*Tool.ScreenScale,null,Color.Blue,0f, new Vector2(50,50),LETMEOUT.Size/100*Tool.ScreenScale,SpriteEffects.None,1);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
