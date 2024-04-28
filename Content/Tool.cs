using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugar.Content
{
    public class Tool
    {
        public static bool CheckOverlap(AABB a, AABB b)
        {
            if (a.Position.X - a.Size.X < b.Position.X + b.Size.X) return false;
            if (b.Position.X - b.Size.X < a.Position.X + a.Size.X) return false;
            if (a.Position.Y - a.Size.Y < b.Position.Y + b.Size.Y) return false;
            if (b.Position.Y - b.Size.Y < a.Position.Y + a.Size.Y) return false;
            return true;
        }
        public static void Resolve(AABB a, AABB b)
        {
            if(!a.Resolve||!b.Resolve) return;
            if(!CheckOverlap(a, b)) return;
            //add resolution function later.
        }
    }
}
