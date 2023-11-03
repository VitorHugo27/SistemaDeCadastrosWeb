using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using SistemaWeb.ConnectionStrings;

namespace SistemaWeb.Models
{
    public class CategoriaDao : DB_Conection
    {
        public void Cadastrar(Categoria categoria)
        {

            String sql = "INSERT INTO Produtos (Nome, Descricao ) " +
                " VALUES (@Nome, @Descricao )";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);
                cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);

                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }
        }

        public List<Categoria> ListarCategoria()
        {
            List<Categoria> list = new List<Categoria>();

            String sql = "SELECT * FROM Categoria; ";

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(GetCategoria(reader));
                }
                con.Close();
            }

            return list;
        }

        private Categoria GetCategoria(SqlDataReader reader)
        {
            Categoria categoria = new Categoria();

            categoria.Id = Convert.ToInt32(reader["Id"]);

            if (reader["Nome"].ToString() != null)
                categoria.Nome = reader["Nome"].ToString();

            if (reader["Descricao"].ToString() != null)
                categoria.Descricao = reader["Descricao"].ToString();

            return categoria;
        }

        public Categoria ListarCategoriaId(int? id)
        {
            Categoria categoria = new Categoria();

            String sql = "SELECT * FROM Categoria WHERE Id = @Id; ";

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categoria = GetCategoria(reader);
                }
                con.Close();
            }
            return categoria;
        }

        public void Edtar(Categoria categoria)
        {
            String sql = "UPDATE Categoria SET Nome = @Nome, Descricao = @Descricao " +
                " WHERE Id = @Id; ";

            using (SqlConnection con = new SqlConnection(Conexao))
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Id", categoria.Id);
                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);
                cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);

                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }
        }

        public void Deletar(int id)
        {
            String sql = "Delete From Categoria Where Id = @Id; ";

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