using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugar
{
    public class Tool
    {
        public static bool CheckOverlap(AABB a, AABB b)
        {
            if (a.Position.X - a.HalfSize.X < b.Position.X + b.HalfSize.X) return false;
            if (b.Position.X - b.HalfSize.X < a.Position.X + a.HalfSize.X) return false;
            if (a.Position.Y - a.HalfSize.Y < b.Position.Y + b.HalfSize.Y) return false;
            if (b.Position.Y - b.HalfSize.Y < a.Position.Y + a.HalfSize.Y) return false;
            return true;
        }
        public static void Resolve(AABB a, AABB b)
        {
            if (!a.Resolve || !b.Resolve) return;
            if (!CheckOverlap(a, b)) return;
            //add resolution function later.
        }
        public static Vector2 ScreenScale = new Vector2(1920,1080);
        public static Vector2 MousePosition = Vector2.Zero;
    }
}
