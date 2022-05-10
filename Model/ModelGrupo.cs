namespace Model;

public class ModelGrupo
{
    private int _id_grupo;
    private string _descricao_grupo;

    public ModelGrupo()
    {
        Id_grupo = 0;
        Descricao_grupo = "";
    }

    public ModelGrupo(int id_grupo, string descricao_grupo)
    {
        Id_grupo = id_grupo;
        Descricao_grupo = descricao_grupo;
    }

    public int Id_grupo { get => _id_grupo; set => _id_grupo = value; }
    public string Descricao_grupo { get => _descricao_grupo; set => _descricao_grupo = value; }
}
