using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormExample
{
    public class Box:Sprite
    {
        public override void paint(Graphics g)
        {
            foreach(Sprite s in children)
            {
                s.X = X;
                s.Y = Y;
            }

            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, 100, 100));

        }
    }
}
