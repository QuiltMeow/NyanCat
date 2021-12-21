using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nyan_Cat
{
    public partial class NyanForm : Form
    {
        public const int NYAN_COUNT = 32, NYAN_UP_COUNT = 2, NYAN_BORDER = 15;

        private Direction direction;
        private int borderX, borderY, origin;

        public NyanForm()
        {
            InitializeComponent();
            Visible = true;

            initBorderLayout();
            initNyan();
            initLocation();
            timerRun.Start();
        }

        ~NyanForm()
        {
            timerRun.Stop();
        }

        private void initBorderLayout()
        {
            borderX = Screen.PrimaryScreen.Bounds.Width;
            borderY = Screen.PrimaryScreen.Bounds.Height;
        }

        private void initLocation()
        {
            int max;
            if (direction == Direction.LEFT || direction == Direction.RIGHT)
            {
                max = borderY - pbNyan.Size.Height - NYAN_BORDER + 1;
            }
            else
            {
                max = borderX - pbNyan.Size.Width - NYAN_BORDER + 1;
            }
            if (NYAN_BORDER >= max)
            {
                max = NYAN_BORDER + 1;
            }
            origin = Program.random.Next(NYAN_BORDER, max);

            switch (direction)
            {
                case Direction.LEFT:
                    {
                        Location = new Point(borderX + 200, origin);
                        break;
                    }
                case Direction.RIGHT:
                    {
                        Location = new Point(-pbNyan.Size.Width - 200, origin);
                        break;
                    }
                case Direction.UP:
                    {
                        Location = new Point(origin, borderY + 200);
                        break;
                    }
                case Direction.DOWN:
                    {
                        Location = new Point(origin, -pbNyan.Size.Height - 200);
                        break;
                    }
            }
        }

        private void pbNyan_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void timerTopMost_Tick(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void initNyan()
        {
            if (Program.random.Next(1000) >= 55)
            {
                direction = Program.random.Next(100) % 2 == 0 ? Direction.LEFT : Direction.RIGHT;
            }
            else
            {
                direction = Program.random.Next(100) % 2 == 0 ? Direction.UP : Direction.DOWN;
            }
            pbNyan.Image = getNyanImage(direction);

            Size size = getImageScaleSize(pbNyan.Image);
            Size = size;
            pbNyan.Size = size;
        }

        private void timerRun_Tick(object sender, EventArgs e)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    {
                        Location = new Point(Location.X - 5, origin);
                        if (Location.X < -pbNyan.Size.Width - 100)
                        {
                            Close();
                        }
                        break;
                    }
                case Direction.RIGHT:
                    {
                        Location = new Point(Location.X + 5, origin);
                        if (Location.X > borderX + 100)
                        {
                            Close();
                        }
                        break;
                    }
                case Direction.UP:
                    {
                        Location = new Point(origin, Location.Y - 5);
                        if (Location.Y < -pbNyan.Size.Height - 100)
                        {
                            Close();
                        }
                        break;
                    }
                case Direction.DOWN:
                    {
                        Location = new Point(origin, Location.Y + 5);
                        if (Location.Y > borderY + 100)
                        {
                            Close();
                        }
                        break;
                    }
            }
        }

        private static Size getImageScaleSize(Image image)
        {
            double scale;
            if (Program.random.Next(100) >= 10)
            {
                scale = Program.random.Next(100, 300 + 1) / 100D;
            }
            else
            {
                scale = Program.random.Next(300 + 1, 1400 + 1) / 100D;
            }
            Size imageSize = image.Size;
            return new Size((int)(imageSize.Width * scale), (int)(imageSize.Height * scale));
        }

        public static Image getNyanImage(Direction target)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("nyan_");
            if (target == Direction.LEFT || target == Direction.RIGHT)
            {
                if (target == Direction.LEFT)
                {
                    sb.Append("left_");
                }
                sb.Append(Program.random.Next(NYAN_COUNT));
            }
            else
            {
                sb.Append("up_");
                Direction face = Program.random.Next(100) % 2 == 0 ? Direction.LEFT : Direction.RIGHT;
                if (face == Direction.LEFT)
                {
                    sb.Append("left_");
                }
                sb.Append(Program.random.Next(NYAN_UP_COUNT));
            }
            return (Image)Properties.Resources.ResourceManager.GetObject(sb.ToString());
        }
    }
}