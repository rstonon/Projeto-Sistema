using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class DadoConexao
{
    public static string StringDeConexao
    {
        get
        {
            return "Server=127.0.0.1;Port=5432;Database=sistema_mira;User Id=postgres;Password=master450;";
        }
    }
}
