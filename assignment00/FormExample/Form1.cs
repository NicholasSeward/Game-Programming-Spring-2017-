using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormExample
{
    public partial class Form1 : Form
    {

        int x;
        int y;
        int cellSize;
        int margin=10;
        int row = -1;
        int col = -1;


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            UpdateSize();
        }

        private void UpdateSize()
        {
            cellSize = (Math.Min(ClientSize.Width, ClientSize.Height) - 2 * margin)/3;
            if(ClientSize.Width> ClientSize.Height)
            {
                x = (ClientSize.Width - 3 * cellSize) / 2;
                y = margin;
            }
            else
            {
                x = margin;
                y= (ClientSize.Height - 3 * cellSize) / 2;
            }
        }

        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);
            UpdateSize();
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            col = (int)Math.Floor((e.X - x)*1.0 / cellSize);
            row = (int)Math.Floor((e.Y - y)*1.0 / cellSize);
            Refresh();
            //base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            //base.OnPaint(e);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Rectangle rect = new Rectangle(x + i * cellSize, y + j * cellSize, cellSize, cellSize);
                    if (i == col && j == row) e.Graphics.FillRectangle(Brushes.Yellow, rect);
                    e.Graphics.DrawRectangle(Pens.Chocolate,rect);
                    System.Drawing.Font font = new System.Drawing.Font("Ubuntu", cellSize*3 * 72 / 96 / 4);
                    e.Graphics.DrawString("X", font, Brushes.Black, x + cellSize / 8, y + cellSize / 8);
                }
        }

    }
    
}
