using Model;
using Npgsql;
using System.Data;

namespace DAL
{
    public class DALGrupo
    {
        private DALConexao conexao;

        public DALGrupo(DALConexao conn)
        {
            this.conexao = conn;
        }

        public void Adicionar(ModelGrupo model)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO grupos set descricao_grupo = @nome; SELECT @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", model.Descricao_grupo);
                conexao.Conectar();
                model.Id_grupo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Editar(ModelGrupo model)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "UPDATE grupos set descricao_grupo = @nome WHERE id_grupo = @codigo";
                cmd.Parameters.AddWithValue("@nome", model.Descricao_grupo);
                cmd.Parameters.AddWithValue("@codigo", model.Id_grupo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Excluir(int codigo)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "DELETE FROM grupos WHERE id_grupo = @codigo";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public DataTable Pesquisa(String valor)
        {
            DataTable tabela = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("Select * from grupos where id_grupo like '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);

            return tabela;
        }

        public ModelGrupo CarregarGrid(int codigo)
        {
            try
            {
                ModelGrupo model = new ModelGrupo();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM grupos WHERE id_grupo = @codigo";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    model.Id_grupo= Convert.ToInt32(dr["id_grupo"]);
                    model.Descricao_grupo = Convert.ToString(dr["descricao_grupo"]);
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
