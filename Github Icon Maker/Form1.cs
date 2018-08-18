using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;


namespace Github_Icon_Maker
{
    public partial class Generator : Form
    {
        static Brush[] colors = new Brush[3];
        static int color = 0;
        static bool draw = true;
        Graphics gfx;
        private Form form;
        private object saveScreenshot;

        public static bool Random()
        {
            Random random = new Random();

            int num = random.Next(0, 2);
            if(num == 1)
            {
                return true;
            }
            else { return false; }

        }
       

        public void makePattern(Graphics gfx, Brush color)
        {
            for (int i = 0; i < 600; i += 50)
            {
                System.Threading.Thread.Sleep(10);
                for (int j = 0; j < 600; j += 50)
                {
                    System.Threading.Thread.Sleep(10);
                    if (Random() == true)
                    {
                        //Console.Beep(500,50);
                        drawSquare(gfx, i, j, 50, color);
                        Console.WriteLine(i + ", " + j);

                    }
                }
            }
        }
        


        
        
        static void drawSquare(Graphics gfx, int x, int y, int size, Brush color)
        {
            //LightBlue
            //LightGreen
            //LightPink
            gfx.FillRectangle(color, x, y, size, size);
        }
        public Generator()
        {
            InitializeComponent();
            gfx = CreateGraphics();
            KeyPreview = true;

            // WaitCallback callback = new WaitCallback(makePattern(Graphics gfx, Brushes.LightGreen));

        }
        public Bitmap DrawControlToImage(Control control)
        {
            Bitmap image = new Bitmap(control.Width, control.Height);
            Graphics graphics = Graphics.FromImage(image);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, Point.Empty, control.Size);
            return image;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

            Menu menu = new Menu(timer1, form, color);
            menu.Show();
            KeyPreview = true;
            
            colors[0] = Brushes.LightBlue;
            colors[1] = Brushes.LightPink;
            colors[2] = Brushes.LightGreen;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (draw)
            {
                //drawSquare(gfx, 0, 0, 50, colors[color]);
                makePattern(gfx, colors[color]);
                //mirrorPattern(gfx);
                draw = false;
            }
           // timer1.Enabled = false;
        }

        private void Generator_Click(object sender, EventArgs e)
        {
            
        }

        private void Generator_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.C)
            {
                Bitmap bitmap = DrawControlToImage(Generator.ActiveForm);
                //SwapClipboardImage((bitmap));
                MessageBox.Show("Press ALT+PrtSc to Copy to Clipboard. Then crop to remove title bar");
            }
            if(e.KeyCode == Keys.R)
            {
                gfx.Clear(Color.White);
                draw = true;
            }
            if(e.KeyCode == Keys.Space)
            {
                if(color < 3)
                {
                    color++;
                }
                else { color = 0; }
                if(color == 0)
                {
                    MessageBox.Show("Color changed to LightBlue" + Environment.NewLine + "Press Space for a different color");
                }
                if (color == 1)
                {
                    MessageBox.Show("Color changed to LightPink" + Environment.NewLine + "Press Space for a different color");

                }
                if (color == 2)
                {
                    MessageBox.Show("Color changed to LightGreen" + Environment.NewLine + "Press Space for a different color");
                }
            }
        }

        private void Generator_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
