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
    public partial class Listar : Form
    {
        private SqlConnection conexao = new SqlConnection(@"Data Source=LEOPOLDO07;Initial Catalog=Leopoldo;Integrated Security=True");
        public Listar()
        {
            InitializeComponent();
        }

        private void Listar_Load(object sender, EventArgs e)
        {

            try
            {

                try
                {
                    conexao.Open();
                    string query = "SELECT * FROM Conta";
                    SqlCommand command = new SqlCommand(query, conexao);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    dataGridView1.DataSource = tabela;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao ler o arquivo: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao listar os dados: " + ex.Message);
            }
            conexao.Close();
        }
    }
    
}
