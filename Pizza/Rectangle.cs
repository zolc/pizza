using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProblem
{
    public class Rectangle
    {
        public int x; public int y;
        public int height; public int length;
        public Rectangle(int _x, int _y, int _h, int _l)
        {
            x = _x;
            y = _y;
            height = _h;
            length = _l;
        }
        public int Size
        {
            get
            {
                return height * length;
            }
        }
        public void Connect(ref Rectangle Base,Rectangle Extension,int maxcells)
        {
            if (Base.Size + Extension.Size > maxcells)
                return;
            if (Base.x != Extension.x)
            {
                if(Base.x>Extension.x)
                Base.x = Extension.x;
                Base.height += Extension.height;
            }
            if (Base.y != Extension.y)
            {
                if (Base.y > Extension.y)
                    Base.y = Extension.y;
                Base.length += Extension.length;
            }
        }
    }
}
