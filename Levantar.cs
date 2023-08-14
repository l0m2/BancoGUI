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
    public partial class Levantar : Form
    {
        public Levantar()
        {
            InitializeComponent();
        }
        double valor;
        private SqlConnection conexao = new SqlConnection(@"Data Source=LEOPOLDO07;Initial Catalog=Leopoldo;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            conexao.Open();
            string query = "select Conta.Saldo from Conta where NrConta ='" + txtConta.Text + "' ";
            SqlCommand command = new SqlCommand(query, conexao);
            object result = command.ExecuteScalar();
            if (result != null)
            {
                valor = double.Parse(result.ToString());
            }

            int aux = int.Parse(txtValor.Text);

            //MessageBox.Show("valor" + aux);
            //MessageBox.Show("dinheiro" + valor);
            if (valor > aux)
            {
                valor -= 5;
                valor -= aux;
                string query1 = "UPDATE Conta SET Saldo = @saldo  WHERE NrConta = @numero";
                SqlCommand command1 = new SqlCommand(query1, conexao);
                command1.Parameters.AddWithValue("@numero", txtConta.Text);
                command1.Parameters.AddWithValue("@saldo", valor);
                try
                {

                    command1.ExecuteNonQuery();

                    MessageBox.Show("Levantamento Efectuado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Levantar Dinheiro: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Saldo Insuficiente para levantar " + aux);

            }
            conexao.Close();
        }
    }
}
