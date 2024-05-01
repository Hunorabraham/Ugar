﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ugar
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        static public List<Image> RenderList = new();
        static public Dictionary<string, Texture2D> TextureList = new();
        static public List<Button> ActiveButtons = new();
        static public int PreviusHoveredButton = -1;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
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
            MenuManager.LoadMainMenu(this);
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
            //check hover
            /*
             * DEBUG
             * if(CurrentState.LeftButton == ButtonState.Pressed)
            {
                System.IO.File.WriteAllText("test.txt",$"{Tool.MousePosition}, {LETMEOUT.collider.Size}, {LETMEOUT.collider.HalfSize}, {LETMEOUT.collider.TestPoint(Tool.MousePosition)}");
            }*/

            //variable for storing the previous hovered button
            ActiveButtons.ForEach(button => button.Color = Color.Blue);
            for (int i = 0; i < ActiveButtons.Count; i++)
            {
                if (ActiveButtons[i].collider.TestPoint(Tool.MousePosition))
                {
                    //check click
                    if (CurrentState.LeftButton == ButtonState.Pressed)
                    {
                        ActiveButtons[i].OnClick.Invoke();
                        if (PreviusHoveredButton != i && PreviusHoveredButton != -1) {
                            ActiveButtons[i].OnHover.Invoke();
                            ActiveButtons[PreviusHoveredButton].OnMouseLeave.Invoke();
                            PreviusHoveredButton = i;
                        }
                        else
                        {
                            ActiveButtons[i].OnHover.Invoke();
                            PreviusHoveredButton = i;
                        }
                        break;
                    }
                    
                    if (PreviusHoveredButton != i && PreviusHoveredButton != -1)
                    {
                        ActiveButtons[i].Color = Color.LightBlue;
                        ActiveButtons[i].OnHover.Invoke();
                        ActiveButtons[PreviusHoveredButton].OnMouseLeave.Invoke();
                        PreviusHoveredButton = i;
                    }
                    else
                    {
                        ActiveButtons[i].Color = Color.LightBlue;
                        ActiveButtons[i].OnHover.Invoke();
                        PreviusHoveredButton = i;
                    }
                    break;
                }
            }

            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin();

            //render the cursor
            // TODO: Add your drawing code here
            foreach (var item in RenderList)
            {
                _spriteBatch.Draw(item.Texture,item.Position*Tool.ScreenScale,null,item.Color,0f,new Vector2(item.Texture.Width/2f,item.Texture.Height/2f),(new Vector2(item.Scale.X/item.Texture.Width,item.Scale.Y/item.Texture.Height))*Tool.ScreenScale,SpriteEffects.None,item.LayerDepth);
            }
            ActiveButtons.Where(x => x.Debug).ToList().ForEach(button => _spriteBatch.Draw(TextureList["DebugTexture0"], button.Position * Tool.ScreenScale, null, button.Color, 0f, new Vector2(50, 50), button.Size / 100 * Tool.ScreenScale, SpriteEffects.None, 1));
            //_spriteBatch.Draw(TextureList["DebugTexture0"],LETMEOUT.Position*Tool.ScreenScale,null,LETMEOUT.Color,0f, new Vector2(50,50),LETMEOUT.Size/100*Tool.ScreenScale,SpriteEffects.None,1);
            //mouse draw, for debug
            _spriteBatch.Draw(TextureList["DebugTexture0"], Tool.MousePosition * Tool.ScreenScale, null, Color.Orange, 0f, new Vector2(50, 50), 10f / 100f, SpriteEffects.None, 1); 
                        
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
