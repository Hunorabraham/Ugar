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
            if (a.Position.X + a.Size.X < b.Position.X || b.Position.X + b.Size.X < a.Position.X) return false;
            if (a.Position.Y + a.Size.Y < b.Position.Y || b.Position.Y + b.Size.Y < a.Position.Y) return false;
            return true;
        }
        public static void Resolve(AABB a, AABB b)
        {
            if (!a.Resolve || !b.Resolve) return;
            if (!CheckOverlap(a, b)) return;
            //add resolution function later.
        }
        public static Vector2 ScreenScale = new Vector2(1920,1080);
        public static Vector2 TempScreenScale = new Vector2(1920,1080);
        public static Vector2 MousePosition = Vector2.Zero;
    }
}
