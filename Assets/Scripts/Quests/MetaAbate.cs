public class MetaAbate : Meta
{
    public int IDMonstro { get; set; }
    public MetaAbate(Quest quest, int idMonstro, string descricao, bool completa, int atingida, int desejada)
    {
        this.quest = quest;
        IDMonstro = idMonstro;
        base.descricao = descricao;
        base.completa = completa;
        base.atingida = atingida;
        base.desejada = desejada;
    }

}
