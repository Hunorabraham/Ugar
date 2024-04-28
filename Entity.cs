﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugar
{
    public class Image
    {
        public Vector2 Position, Scale;
        public Texture2D Texture;
        public float LayerDepth;
        public Image(Texture2D texture, Vector2 position, Vector2 scale, float layer)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
            LayerDepth = layer;
        }

    }
    public class AABB {
        //position is centered, Size is half of the actual size
        public Vector2 Position, Size;
        public Vector2 ActualSize { get { return Size * 2; } }
        //boolean for collision function to resolve overlaps automatically
        public bool Resolve;
        public AABB(Vector2 position, Vector2 size, bool resolve) { 
            Position = position;
            Size = size/2;
            Resolve = resolve;
        }
        public bool TestPoint(Vector2 point)
        {
            if(Position.X-Size.X<point.X || Position.X+Size.X>point.X) return false;
            if(Position.Y-Size.Y<point.Y || Position.Y+Size.Y>point.Y) return false;
            return true;
        }
    }
    public class Entity
    {
        //position is centered, Size is the Actual size
        public Vector2 Position, Velocity, Forces, Size;
        public float Weight;
        public Func<int> AIUpdate;
        //it's collider
        public AABB collider;
        public Entity() {
            
        }
        public void AddForce(Vector2 incomingForce)
        {
            Forces += incomingForce / Weight;
        }
        public void Update()
        {
            AIUpdate.Invoke();
            Velocity += Forces;
            Forces = Vector2.Zero;
            Position += Velocity;

        }
    }
}
