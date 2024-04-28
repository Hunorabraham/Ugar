using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Mime;
using Ugar;

public class MenuManager
{
    static public void LoadAll(ContentManager Content)
    {
        Game1.TextureList.Add("Tablicsku",Content.Load<Texture2D>("Tablicsku"));
        Game1.TextureList.Add("DebugTexture0", Content.Load<Texture2D>("square"));
    }
    static public void LoadMainMenu()
    {
        Game1.RenderList.Clear();
        Game1.RenderList.Add(new Image(Game1.TextureList["Tablicsku"],new Vector2(1550,450),new Vector2(0.38f,0.38f),0));
    }
}
