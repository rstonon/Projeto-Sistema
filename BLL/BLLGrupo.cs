using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class BLLGrupo
    {
        private DALConexao conexao;

        public BLLGrupo(DALConexao conn)
        {
            this.conexao = conn;
        }

        public void Adicionar(ModelGrupo model)
        {
            if (model.Descricao_grupo.Trim().Length == 0)
            {
                throw new Exception("O nome do grupo é obrigatório!");
            }

            DALGrupo obj = new DALGrupo(conexao);
            obj.Adicionar(model);
        }

        public void Editar(ModelGrupo model)
        {
            if (model.Id_grupo <= 0)
            {
                throw new Exception("O código do grupo é obrigatório!");
            }

            if (model.Descricao_grupo.Trim().Length == 0)
            {
                throw new Exception("O nome do grupo é obrigatório!");
            }

            DALGrupo obj = new DALGrupo(conexao);
            obj.Editar(model);
        }

        public void Excuir(int codigo)
        {
            DALGrupo obj = new DALGrupo(conexao);
            obj.Excluir(codigo);
        }

        public DataTable Pesquisa(String valor)
        {
            DALGrupo obj = new DALGrupo(conexao);
            return obj.Pesquisa(valor);
        }

        public ModelGrupo CarregarGrid(int codigo)
        {
            DALGrupo obj = new DALGrupo(conexao);
            return obj.CarregarGrid(codigo);
        }
    }
}
