using Microsoft.Xna.Framework;
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
            Game1.TextureList.Add("Tablicsku", Content.Load<Texture2D>("Tablicsku"));
            Game1.TextureList.Add("DebugTexture0", Content.Load<Texture2D>("square"));
            Game1.TextureList.Add("QuitLabel",Content.Load<Texture2D>("quitText"));
            Game1.TextureList.Add("Play", Content.Load<Texture2D>("Pannonia"));
            Game1.TextureList.Add("Settings", Content.Load<Texture2D>("Resolution"));
            Game1.TextureList.Add("Logs", Content.Load<Texture2D>("Biblioteca"));
        }
        static public void LoadMainMenu(Game1 T)
        {
            Game1.RenderList.Clear();
            Game1.PreviusHoveredButton = -1;
            Game1.RenderList.Add(new Image(Game1.TextureList["Tablicsku"], new Vector2(0.85f, 0.7f), new Vector2(0.3f, 0.6f), 0));
            Game1.ActiveButtons.Add(new Button(0.87f, 0.52f, 0.23f, 0.08f, Game1.TextureList["Play"], () => { return 0; }));
            Game1.ActiveButtons.Add(new Button(0.85f, 0.65f, 0.23f, 0.08f, Game1.TextureList["Logs"], () => { return 0; }));
            Game1.ActiveButtons.Add(new Button(0.84f, 0.76f, 0.23f, 0.08f, Game1.TextureList["Settings"], () => { return 0; }));
            Game1.ActiveButtons.Add(new Button(0.86f, 0.88f, 0.23f, 0.08f, Game1.TextureList["QuitLabel"], () => { T.Exit(); return 0; }));
        }
    }
}
