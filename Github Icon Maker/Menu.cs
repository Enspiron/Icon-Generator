using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Github_Icon_Maker
{
    public partial class Menu : Form
    {
        
        private object v;
        public Form form;
        private Brush[] colors;
        private int color;

        public Menu(Form form)
        {
            InitializeComponent();
            this.form = form;

        }

        public Menu(object v, Form form)
        {
            InitializeComponent();

            this.v = v;
        }

        public Menu(Timer timer1, Form form)
        {
            InitializeComponent();

            //this.timer1 = timer1;
        }

        public Menu(Timer timer1, Form form, int color) : this(timer1, form)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            InitializeComponent();

            this.color = color;
            this.timer1 = timer1;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            if (color == 0)
            {
                colorText.Text = "LightBlue";
            }
            if (color == 1)
            {
                colorText.Text = "LightPink";
            }
            if (color == 2)
            {
                colorText.Text = "LightGreen";
            }
        
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A screenshot of the window will be saved." + Environment.NewLine + Environment.NewLine + "The screenshot will contain the title bar so you should crop it. ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
