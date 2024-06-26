﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace Ugar
{
    public class MenuManager
    {
        static public void LoadAll(ContentManager Content)
        {
            Game1.TextureList.Add("Tablicsku", Content.Load<Texture2D>("img/Tablicsku"));
            Game1.TextureList.Add("DebugTexture0", Content.Load<Texture2D>("img/square"));
            Game1.TextureList.Add("QuitLabel",Content.Load<Texture2D>("img/quitText"));
            Game1.TextureList.Add("Play", Content.Load<Texture2D>("img/Pannonia"));
            Game1.TextureList.Add("Settings", Content.Load<Texture2D>("img/Resolution"));
            Game1.TextureList.Add("Logs", Content.Load<Texture2D>("img/Biblioteca"));
            Game1.TextureList.Add("Back", Content.Load<Texture2D>("img/Back"));
            Game1.TextureList.Add("Apply", Content.Load<Texture2D>("img/Apply"));
            Game1.TextureList.Add("Mouse", Content.Load<Texture2D>("img/Arrow"));
            Game1.TextureList.Add("MenuBackgroundLayer1", Content.Load<Texture2D>("img/Eclipse"));
            Game1.TextureList.Add("MenuBackgroundLayer2", Content.Load<Texture2D>("img/Mountain"));
            Game1.TextureList.Add("MenuBackgroundLayer3", Content.Load<Texture2D>("img/Kapu"));
            Game1.TextureList.Add("MenuBackgroundLayer4", Content.Load<Texture2D>("img/Bottom"));
            Game1.TextureList.Add("SettingsBackground", Content.Load<Texture2D>("img/SettingsSign"));
            Game1.TextureList.Add("HD", Content.Load<Texture2D>("img/ResolutionHD"));
            Game1.TextureList.Add("FWXGA", Content.Load<Texture2D>("img/Resolution1366"));
            Game1.TextureList.Add("HD+", Content.Load<Texture2D>("img/Resolution1600"));
            Game1.TextureList.Add("FullHD", Content.Load<Texture2D>("img/ResolutionFullHD"));
        }
        static public void LoadMainMenu(Game1 T)
        {
            Game1.RenderList.Clear();
            Game1.ActiveButtons.Clear();
            Game1.InMenu = true;
            Game1.PreviusHoveredButton = -1;
            Game1.RenderList.Add(new Image(Game1.TextureList["MenuBackgroundLayer1"], new Vector2(0.5f, 0.5f), new Vector2(1.1f, 1f), 0));
            Game1.RenderList.Add(new Image(Game1.TextureList["MenuBackgroundLayer2"], new Vector2(0.5f, 0.5f), new Vector2(1.1f, 1.1f), 0));
            Game1.RenderList.Add(new Image(Game1.TextureList["MenuBackgroundLayer3"], new Vector2(0.5f, 0.5f), new Vector2(1.1f, 1.1f), 0));
            Game1.RenderList.Add(new Image(Game1.TextureList["MenuBackgroundLayer4"], new Vector2(0.5f, 0.5f), new Vector2(1.25f, 1.12f), 0));
            Game1.RenderList.Add(new Image(Game1.TextureList["Tablicsku"], new Vector2(0.85f, 0.7f), new Vector2(0.3f, 0.6f), 0));
            Game1.ActiveButtons.Add(new Button(0.87f, 0.52f, 0.23f, 0.08f, Game1.TextureList["Play"], () => { LoadCharacterSelect(T); return 0; }));
            Game1.ActiveButtons.Add(new Button(0.85f, 0.65f, 0.23f, 0.08f, Game1.TextureList["Logs"], () => { return 0; }));
            Game1.ActiveButtons.Add(new Button(0.84f, 0.76f, 0.23f, 0.08f, Game1.TextureList["Settings"], () => { LoadSettings(T); return 0; }));
            Game1.ActiveButtons.Add(new Button(0.86f, 0.88f, 0.23f, 0.08f, Game1.TextureList["QuitLabel"], () => { T.Exit(); return 0; }));
        }
        static public void LoadSettings(Game1 T)
        {
            Game1.RenderList.Clear();
            Game1.ActiveButtons.Clear();
            Game1.PreviusHoveredButton = -1;
            Game1.InMenu = false;
            Game1.RenderList.Add(new Image(Game1.TextureList["SettingsBackground"], new Vector2(0.5f, 0.5f), new Vector2(1f, 1f), 0));
            Game1.ActiveButtons.Add(new Button(0.24f, 0.78f, 0.23f, 0.08f, Game1.TextureList["Back"], () => { MenuManager.LoadMainMenu(T); return 0; }));
            Game1.ActiveButtons.Add(new Button(0.24f, 0.20f, 0.23f, 0.08f, Game1.TextureList["HD"], () => { Tool.TempScreenScale = new Vector2(1280, 720); return 0; }));
            Game1.ActiveButtons.Add(new Button(0.24f, 0.30f, 0.23f, 0.08f, Game1.TextureList["FWXGA"], () => { Tool.TempScreenScale = new Vector2(1366, 768); return 0; }));
            Game1.ActiveButtons.Add(new Button(0.24f, 0.40f, 0.23f, 0.08f, Game1.TextureList["HD+"], () => { Tool.TempScreenScale = new Vector2(1600, 900); return 0; }));
            Game1.ActiveButtons.Add(new Button(0.24f, 0.50f, 0.23f, 0.08f, Game1.TextureList["FullHD"], () => { Tool.TempScreenScale = new Vector2(1920, 1080); return 0; }));
            Game1.ActiveButtons.Add(new Button(0.77f, 0.77f, 0.23f, 0.08f, Game1.TextureList["Apply"], () => { Tool.ScreenScale = Tool.TempScreenScale; T._graphics.PreferredBackBufferWidth = (int)Tool.ScreenScale.X; T._graphics.PreferredBackBufferHeight = (int)Tool.ScreenScale.Y; T._graphics.ApplyChanges(); return 0; }));

        }
        static public void LoadCharacterSelect(Game1 T)
        {
            Game1.RenderList.Clear();
            Game1.ActiveButtons.Clear();
            Game1.PreviusHoveredButton = -1;
            Game1.InMenu = false;
            Game1.RenderList.Add(new Image(Game1.TextureList["SettingsBackground"], new Vector2(0.5f, 0.5f), new Vector2(1f, 1f), 0));
            Game1.ActiveButtons.Add(new Button(0.24f, 0.78f, 0.23f, 0.08f, Game1.TextureList["Back"], () => { MenuManager.LoadMainMenu(T); return 0; }));
            Game1.ActiveButtons.Add(new Button(0.20f, 0.39f, 0.18f, 0.42f, Game1.TextureList["DebugTexture0"], () => { T.Exit(); return 0; }));
            Game1.RenderList.Add(new Image(Game1.TextureList["DebugTexture0"], new Vector2(0.20f, 0.34f), new Vector2(0.16f, 0.29f), 0));
            Game1.ActiveButtons.Add(new Button(0.39f, 0.39f, 0.18f, 0.42f, Game1.TextureList["DebugTexture0"], () => { T.Exit(); return 0; }));
            Game1.RenderList.Add(new Image(Game1.TextureList["DebugTexture0"], new Vector2(0.39f, 0.34f), new Vector2(0.16f, 0.29f), 0));
            Game1.ActiveButtons.Add(new Button(0.58f, 0.39f, 0.18f, 0.42f, Game1.TextureList["DebugTexture0"], () => { T.Exit(); return 0; }));
            Game1.RenderList.Add(new Image(Game1.TextureList["DebugTexture0"], new Vector2(0.58f, 0.34f), new Vector2(0.16f, 0.29f), 0));
            Game1.ActiveButtons.Add(new Button(0.77f, 0.39f, 0.18f, 0.42f, Game1.TextureList["DebugTexture0"], () => { T.Exit(); return 0; }));
            Game1.RenderList.Add(new Image(Game1.TextureList["DebugTexture0"], new Vector2(0.77f, 0.34f), new Vector2(0.16f, 0.29f), 0));

        }
    }
}
