using System;
using System.Numerics;

public class Button
{
	public Vector2 Position, Size;
	public Func<int> OnClick;
	public Button(Vector2 pos, Vector2 size, Func<int> onclick)
	{  
		Position = pos; 
		Size = size; 
		OnClick = onclick;
	}
	public Button(float x, float y, float width, float height, Func<int> onclick) 
	{
		Position = new Vector2(x, y);
		Size = new Vector2(width, height);
		OnClick = onclick;
	}
}
