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
    }
    static void LoadMainMenu()
    {
        Game1.RenderList.Clear();
        Game1.RenderList.Add(new Image(Game1.TextureList["Tablicsku"],new Vector2(0,0),new Vector2(100,100),0));
    }
}
