using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public SnakeList lst = new SnakeList();
        private Timer time;
        private bool b = true;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            time = new Timer();
            time.Interval = 100;
            time.Tick += new EventHandler(MoveSnake);
            lst.form = this;

            lst.CreateSnake();
            lst.CreateBean();
            lst.gra = this.CreateGraphics();
        }

        private void ShowWall()
        {
            Graphics p = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            p.DrawRectangle(pen, 0, 0, 500, 500);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (b == true)
            {
                ShowWall();
                lst.ShowBean();
                lst.ShowSnake();
                b = !b;
            }
            //Graphics gra = this.CreateGraphics();
            //gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Pen pen = new Pen(Color.Black);//画笔颜色      
            //gra.DrawEllipse(pen, 140, 100, 20, 20);
            //Invalidate();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            base.ProcessCmdKey(ref msg, keyData);
            switch (keyData)
            {

                case Keys.Right:
                    {
                        if (lst.dt != DirectionType.DT_Left)
                        {
                            lst.dt = DirectionType.DT_Right;
                        }
                    }
                    break;

                case Keys.Left:
                    {
                        if (lst.dt != DirectionType.DT_Right)
                        {
                            lst.dt = DirectionType.DT_Left;
                        }
                    }
                    break;

                case Keys.Up://方向键不反应
                    {
                        if (lst.dt != DirectionType.DT_Down)
                        {
                            lst.dt = DirectionType.DT_Up;
                        }
                    }
                    break;

                case Keys.Down:
                    {
                        if (lst.dt != DirectionType.DT_Up)
                        {
                            lst.dt = DirectionType.DT_Down;
                        }
                    }
                    break;

                case Keys.Space:
                    {
                        time.Stop();
                    }
                    break;

                case Keys.Enter:
                    {
                        time.Start();
                    }
                    break;

            }
            return true;
        }

        public void MoveSnake(object value, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            if (!lst.Eat())
            {
                lst.Move();
            }
            
            ShowWall();
            lst.ShowBean();
            lst.ShowSnake();
        }
    }
}
