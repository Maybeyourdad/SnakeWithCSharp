using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public enum DirectionType
    {
        DT_Right = 0,
        DT_Left,
        DT_Up,
        DT_Down,
    }
    public class SnakeList
    {
        public Graphics gra { get; set; }
        public List<Point> list = new List<Point>();
        Point bean = new Point();
        private const int nSize = 20;
        public DirectionType dt { get; set; }
        public Form form { get; set; }
        public SnakeList()
        {

        }

        public void CreateSnake()
        {
            for (int i = 0; i < 3; i++ )
            {
                Point po = new Point();
                po.X = i * nSize;
                po.Y = 0;
                list.Add(po);
            }
        }

        public void CreateBean()
        {
            Random rd = new Random();
            bean.X = rd.Next(0, 25) * nSize;
            bean.Y = rd.Next(0, 25) * nSize;
        }

        public void ShowSnake()
        {
            foreach (Point po in list)
            {
                Pen pen = new Pen(Color.Blue, 2);
                gra.DrawRectangle(pen, po.X, po.Y, 20, 20);
            }
        }

        public void ShowBean()
        {
            Pen pen = new Pen(Color.Black, 2);
            gra.DrawEllipse(pen, bean.X, bean.Y, 20, 20);
        }

        public bool Move()
        {
            Point po = list[0];
            switch (dt)
            {
                case DirectionType.DT_Right:
                    {
                        po.X = list[list.Count - 1].X + nSize;
                        po.Y = list[list.Count - 1].Y;
                    }
                    break;
                case DirectionType.DT_Left:
                    {
                        po.X = list[list.Count - 1].X - nSize;
                        po.Y = list[list.Count - 1].Y;
                    }
                    break;
                case DirectionType.DT_Up:
                    {
                        po.X = list[list.Count - 1].X;
                        po.Y = list[list.Count - 1].Y - nSize;
                    }
                    break;
                case DirectionType.DT_Down:
                    {
                        po.X = list[list.Count - 1].X;
                        po.Y = list[list.Count - 1].Y + nSize;
                    }
                    break;
            }
            
            list.Remove(list[0]);
            list.Add(po);
            return true;
        }

        public bool Eat()
        {
            if (CanEat())
            {
                Point po = new Point();
                po.X = bean.X;
                po.Y = bean.Y;
                list.Add(po);

                CreateBean();
                return true;
            }

            return false;
        }

        private bool CanEat()
        {
            switch (dt)
            {
                case DirectionType.DT_Right:
                    {
                        if (list[list.Count - 1].X + 20 == bean.X && list[list.Count - 1].Y == bean.Y)
                        {
                            return true;
                        }
                    }
                    break;
                case DirectionType.DT_Left:
                    {
                        if (list[list.Count - 1].X - 20 == bean.X && list[list.Count - 1].Y == bean.Y)
                        {
                            return true;
                        }
                    }
                    break;
                case DirectionType.DT_Up:
                    {
                        if (list[list.Count - 1].Y - 20 == bean.Y && list[list.Count - 1].X == bean.X)
                        {
                            return true;
                        }
                    }
                    break;
                case DirectionType.DT_Down:
                    {
                        if (list[list.Count - 1].Y + 20 == bean.Y && list[list.Count - 1].X == bean.X)
                        {
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }
    }
}
