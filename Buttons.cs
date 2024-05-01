using Microsoft.Xna.Framework;
using System;
using Ugar;

public class Button
{
	public Vector2 Position, Size;
	public Color Color = Color.Blue;
	public AABB collider;
    public bool Debug = false;
    public Func<int> OnClick, OnHover, OnMouseLeave;
    public Button(float x, float y, float width, float height, Func<int> onclick, Func<int> onHover, Func<int> onMouseLeave)
    {
        Position = new Vector2(x, y);
        Size = new Vector2(width, height);
        collider = new AABB(Position, Size, false);
        OnClick = onclick;
        OnHover = onHover;
        OnMouseLeave = onMouseLeave;
    }
    public Button(float x, float y, float width, float height, Func<int> onclick, Func<int> onHover, Func<int> onMouseLeave, bool debug)
    {
        Position = new Vector2(x, y);
        Size = new Vector2(width, height);
        collider = new AABB(Position, Size, false);
        OnClick = onclick;
        OnHover = onHover;
        OnMouseLeave = onMouseLeave;
        Debug = debug;
    }
}
