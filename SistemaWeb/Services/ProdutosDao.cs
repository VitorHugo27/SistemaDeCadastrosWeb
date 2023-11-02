using Antlr.Runtime;
using SistemaWeb.ConnectionStrings;
using SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaWeb.Services
{
    public class ProdutosDao : DB_Conection
    {
        public void Cadastrar(Produtos produtos)
        {
            String sql = "INSERT INTO Produtos (Nome, Descricao, Lote, Valor, Fornecedor, Quantidade, Foto, DataCadastro) " +
                " VALUES (@Nome, @Descricao, @Lote, @Valor, @Fornecedor, @Quantidade, @Foto, @DataCadastro)";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", produtos.Nome);
                cmd.Parameters.AddWithValue("@Descricao", produtos.Descricao);
                cmd.Parameters.AddWithValue("@Lote", produtos.Lote);
                cmd.Parameters.AddWithValue("@Valor", produtos.Valor);
                cmd.Parameters.AddWithValue("@Fornecedor", produtos.Fornecedor);
                cmd.Parameters.AddWithValue("@Quantidade", produtos.Quantidade);
                cmd.Parameters.AddWithValue("@Foto", produtos.Foto);
                cmd.Parameters.AddWithValue("@DataCadastro", produtos.DataCadastro);

                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }
        }

        public List<Produtos> ListarProdutos()
        {
            List<Produtos> list = new List<Produtos>();

            String sql = "SELECT * FROM Produtos; ";

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(GetProdutos(reader));
                }
                con.Close();
            }

            return list;
        }

        public Produtos GetProdutos(SqlDataReader reader)
        {
            Produtos produtos = new Produtos();

            produtos.Id = Convert.ToInt32(reader["Id"]);

            if (reader["Nome"].ToString() != null)
                produtos.Nome = reader["Nome"].ToString();

            if (reader["Descricao"].ToString() != null)
                produtos.Descricao = reader["Descricao"].ToString();

            if (reader["Lote"].ToString() != null)
                produtos.Lote = reader["Lote"].ToString();

            if (reader["Valor"].ToString() != null)
                produtos.Valor = Convert.ToDecimal(reader["Valor"]);

            if (reader["Fornecedor"].ToString() != null)
                produtos.Fornecedor = reader["Fornecedor"].ToString();

            produtos.Quantidade = Convert.ToInt32(reader["Quantidade"]);

            if (reader["Foto"].ToString() != null)
                produtos.Foto = reader["Foto"].ToString();

            produtos.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
            return produtos;
        }

        public Produtos ListarProdutosId(int id)
        {
            Produtos produtos = new Produtos();

            String sql = "SELECT * FROM Produtos WHERE Id = @Id; ";

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    produtos = GetProdutos(reader);
                }
                con.Close();
            }
            return produtos;
        }

        public void Edtar(Produtos produtos)
        {

            String sql = "UPDATE Produtos SET Nome = @Nome, Descricao = @Descricao, Lote = @Lote, Valor = @Valor, Fornecedor = @Fornecedor, Quantidade = @Quantidade, Foto = @Foto " +
                " WHERE Id = @Id; ";

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Id", produtos.Id);
                cmd.Parameters.AddWithValue("@Nome", produtos.Nome);
                cmd.Parameters.AddWithValue("@Descricao", produtos.Descricao);
                cmd.Parameters.AddWithValue("@Lote", produtos.Lote);
                cmd.Parameters.AddWithValue("@Valor", produtos.Valor);
                cmd.Parameters.AddWithValue("@Fornecedor", produtos.Fornecedor);
                cmd.Parameters.AddWithValue("@Quantidade", produtos.Quantidade);
                cmd.Parameters.AddWithValue("@Foto", produtos.Foto);

                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }
        }

        public void Deletar(int id)
        {
            String sql = "Delete From Produtos Where Id = @Id; ";

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }
        }

    }
}
