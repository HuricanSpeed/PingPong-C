namespace PingPong
{
    public partial class Form1 : Form
    {
        static int locX;
        static int locY;
        static int speedX;
        static int speedY;

        Player first;
        Player second;

        public Form1()
        {
            InitializeComponent();
            locX = 120;
            locY = 160;
            speedX = 4;
            speedY = 4;
            DoubleBuffered = true;
            timer1.Start();
            first = new Player();
            second = new Player();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ball.direction.Y = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            label1.Text = first.score.ToString();
            label2.Text = second.score.ToString();

            if (locX >= panel2.Location.X - 10 && locX <= panel2.Location.X + panel2.Width && locY >= panel2.Location.Y && locY <= panel2.Location.Y + panel2.Height)
            {
                Ball.direction.X = -1;
            }
            
            if (locX <= panel1.Location.X + panel1.Width && locX >= panel1.Location.X && locY >= panel1.Location.Y && locY <= panel1.Location.Y + panel1.Height)
            {
                Ball.direction.X = 1;
            }

            if(locY <= 0)
            {
                Ball.direction.Y = 1;
            }

            if(locY >= Height - 50)
            {
                Ball.direction.Y = -1;
            }

            if(locX <= 0)
            {
                locX = Width/2;
                locY = Height/2;
                Ball.direction.X = 1;
                Ball.direction.Y = 1;
                first.score++;
            }

            if (locX >= Width)
            {
                locX = Width / 2;
                locY = Height / 2;
                Ball.direction.X = 1;
                Ball.direction.Y = 1;
                second.score++;
            }

            locX += speedX * Ball.direction.X;
            locY += speedY * Ball.direction.Y;



            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawCircle(locX, locY, e.Graphics);
        }
        private void drawCircle(int x, int y, Graphics g)
        {
           
            Pen skyBluePen = new Pen(Color.Black, 2);
            g.DrawEllipse(
                skyBluePen, x, y, 10, 10);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                if(panel1.Location.Y > 0)
                {
                    panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 10);
                }
            }

            if (e.KeyCode == Keys.S)
            {
                if (panel1.Location.Y + panel1.Height < Height - panel1.Height/5)
                {
                    panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 10);
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (panel2.Location.Y > 0)
                {
                    panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - 10);
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (panel2.Location.Y + panel2.Height < Height - panel2.Height / 5)
                {
                    panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 10);
                }
            }
        }
    }
}