using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FormExample
{
    public class Sprite
    {
        //instance variable
        private float x=0;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        private float y = 0;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        private float scale = 1;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        protected List<Sprite> children = new List<Sprite>();


        //constructors

        //methods
        public void render(Graphics g)
        {
            Matrix original = g.Transform.Clone();
            g.ScaleTransform(scale,scale);
            g.TranslateTransform(x, y);
            paint(g);
            foreach(Sprite s in children)
            {
                s.render(g);
            }
            g.Transform = original;
        }

        public virtual void paint(Graphics g)
        {

        }

        public void add(Sprite s)
        {
            children.Add(s);
        }



    }
}
