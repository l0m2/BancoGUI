using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class Form1 : Form
    {
        private Form currentChildForm;
        public Form1()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            CLIENTES add = new CLIENTES();
            //chamar outro form
            OpenChildForm(new CLIENTES());
        }

        private void btn_Deposito_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Operacoes());
        }

        private void btnLevantar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Levantar());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
