using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Ugar;

public class Button
{
	public Vector2 Position, Size;
    public Image Img;
	public Color Color = Color.Blue;
	public AABB collider;
    public bool Debug = false;
    public Func<int> OnClick;
    public Button(float x, float y, float width, float height, Texture2D texture, Func<int> onclick)
    {
        Position = new Vector2(x, y);
        Size = new Vector2(width, height);
        collider = new AABB(Position, Size, false);
        Img = new Image(texture,new Vector2(x, y),new Vector2(width,height),0);
        Img.Color = Color.Black;
        OnClick = onclick;
        Game1.RenderList.Add(Img);
    }
    public Button(float x, float y, float width, float height, Texture2D texture, Func<int> onclick, bool debug)
    {
        Position = new Vector2(x, y);
        Size = new Vector2(width, height);
        collider = new AABB(Position, Size, false);
        Img = new Image(texture, new Vector2(x, y), new Vector2(width, height), 0);
        Img.Color = Color.Black;
        OnClick = onclick;
        Debug = debug;
        Game1.RenderList.Add(Img);
    }
    public void OnHover()
    {
        Img.Color = Color.White;
    }
    public void OnMouseLeave()
    {
        Img.Color = Color.Black;
    }
}
