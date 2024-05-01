using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Mime;

namespace Ugar
{
    public class MenuManager
    {
        static public void LoadAll(ContentManager Content)
        {
            Game1.TextureList.Add("Tablicsku", Content.Load<Texture2D>("Tablicsku"));
            Game1.TextureList.Add("DebugTexture0", Content.Load<Texture2D>("square"));
            Game1.TextureList.Add("QuitLabel",Content.Load<Texture2D>("quitText"));
        }
        static public void LoadMainMenu(Game1 T)
        {
            Game1.RenderList.Clear();
            Game1.PreviusHoveredButton = -1;
            Game1.RenderList.Add(new Image(Game1.TextureList["Tablicsku"], new Vector2(0.85f, 0.7f), new Vector2(0.3f, 0.6f), 0));
            Game1.RenderList.Add(new Image(Game1.TextureList["QuitLabel"], new Vector2(0.86f,0.88f),new Vector2(0.23f,0.08f), 0, Color.Black));
            Game1.ActiveButtons.Add(new Button(0.86f, 0.88f, 0.23f, 0.08f, () => { T.Exit(); return 0; }, () => { Game1.RenderList[1].Color = Color.White; return 0; }, () => { Game1.RenderList[1].Color = Color.Black; return 0; }));
        }
    }
}
