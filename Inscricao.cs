using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Windows.Forms;
using System.IO;

namespace Banco
{
    public partial class CLIENTES : Form
    {
        private Form currentChildForm;
        public CLIENTES()
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
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        //Conexao BD
        SqlConnection sqlCon = null;
        private string strCon = @"Data Source=LEOPOLDO07; integrated security=SSPI; initial catalog = Leopoldo";
        private string strSql = string.Empty;

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            strSql = "INSERT INTO Conta (Nome, Telefone, Email, Saldo)" +
       "VALUES (@Nome, @Telefone, @Email, @Saldo)";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            //Informando que o @Nome no strCon eh um parametro e recebe o valor do text_Nome e para outras variaveis 
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = textNome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = maskedTextTelefone.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = textEmail.Text;
            comando.Parameters.Add("@Saldo", SqlDbType.VarChar).Value = double.Parse(textSaldo.Text);
            try
            {
                sqlCon.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro efetuado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //fechar sql
            finally
            {
                sqlCon.Close();
            }
            textNome.Clear();
            textEmail.Clear();
            textSaldo.Clear(); 
            maskedTextTelefone.Clear();
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Listar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Listar());                
        }
    }
}
