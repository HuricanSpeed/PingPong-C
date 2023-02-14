namespace PingPong
{
    public partial class Form1 : Form
    {
        static int locX;
        static int locY;
        static int speedX;
        static int speedY;
        public Form1()
        {
            InitializeComponent();
            locX = 80;
            locY = 120;
            speedX = 1;
            speedY = 0;
            DoubleBuffered = true;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // levá kolize
            if (locX < panel1.Location.X + panel1.Width)
            {
                Ball.direction.X = 1;
                Console.WriteLine("Jedu do prava");
            }
            //pravá kolize
            if (locX > panel2.Location.X)
            {
                Ball.direction.X = -1;
                Console.WriteLine("Jedu do leva");
            }
            locX += Ball.direction.X;
            locY += Ball.direction.Y;


            locX += speedX;
            locY += speedY;
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

    }
}