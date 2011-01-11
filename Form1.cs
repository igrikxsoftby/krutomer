using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace krutomer
{
    public partial class Form1 : Form
    {
        private Krutomer krutomer = new Krutomer();
        public Form1()
        {
            InitializeComponent();
            krutomer.Captha += new Krutomer.InputCaptha(krutomer_Captha);
        }

        // вывод капчи на экран
        private void krutomer_Captha(object sender, Image image)
        {
            capthaBox.Image = image;
        }

        private void http_Message(object sender, string message)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            krutomer.Register();
        }
    }
}
