using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;


namespace FormExample
{
    public partial class Form1 : Form
    {
        public static Form form;
        public static Thread thread;
        public static int s = 100;
        public static int fps = 30;
        public static double running_fps = 30.0;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            form = this;
            thread = new Thread(new ThreadStart(run));
            thread.Start();

        }

        public static void run()
        {
            DateTime last = DateTime.Now;
            DateTime now = last;
            TimeSpan frameTime = new TimeSpan(10000000 / fps);
            while (true)
            {
                DateTime temp = DateTime.Now;
                running_fps = .9 * running_fps + .1 * 1000.0 / (temp - now).TotalMilliseconds;
                Console.WriteLine(running_fps);
                now = temp;
                TimeSpan diff = now - last;
                if (diff.TotalMilliseconds< frameTime.TotalMilliseconds)
                    Thread.Sleep((frameTime-diff).Milliseconds);
                last = DateTime.Now;
                
                s++;
                form.Invoke(new MethodInvoker(form.Refresh));
                
            }
        }

        private void UpdateSize()
        {
            
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            thread.Abort();
        }

        protected override void OnResize(EventArgs e)
        {

            
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //Refresh();
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Console.WriteLine(s);
            int v = (int)(200 + 100 * Math.Sin(s / 10.0));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0,v, v));
            
        }


    }
    
}
