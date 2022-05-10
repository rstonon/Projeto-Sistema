using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class DALConexao
{
    private string _stringConexao;
    private NpgsqlConnection _conexao;

    public DALConexao(string dadosConexao)
    {
        this._conexao = new NpgsqlConnection();
        this.StringConexao = dadosConexao;
        this._conexao.ConnectionString = dadosConexao;
    }

    public string StringConexao
    {
        get => _stringConexao; set => _stringConexao = value;
    }
    public NpgsqlConnection ObjetoConexao
    {
        get => _conexao; set => _conexao = value;
    }

    public void Conectar()
    {
        this._conexao.Open();
    }

    public void Desconectar()
    {
        this._conexao.Close();
    }
}
