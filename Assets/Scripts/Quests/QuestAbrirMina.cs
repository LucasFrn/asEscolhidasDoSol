using UnityEngine;

public class QuestAbrirMina : Quest
{
    void Start()
    {
        Nome = "Um jeito de entrar";
        Descricao = "Preciso dar um jeito de abrir essa mina pra pegar um pouco de *ADAMANTITA* lá dentro";
        RecompensaXp = 5000;
        Metas = new System.Collections.Generic.List<Meta>();
        Metas.Add(new MetaColeta(this,"Alavanca da Mina", "Encontre a alavanca da mina", false, 0, 1));
        Metas.Add(new MetaExploracao(this, "Devolva a alavanca", false, 0, 1));
    }
    public void Coletar(Component sender, object data)
    {
        //Este método será chamado por um evento que ocorre quando o item é coletado
        if (data is string)
        {
            foreach (MetaColeta m in Metas)
            {
                if ((string)data == m.nomeItem)
                {
                    m.atingida++;
                    m.Conferir();
                }
            }
        }
    }
    public void Entregar()
    {
        foreach (MetaExploracao m in Metas)
        {
            m.atingida++;
            m.Conferir();
        }
    }
}
