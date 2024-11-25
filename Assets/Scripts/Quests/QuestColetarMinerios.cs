using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestColetarMinerios : Quest
{
    void Start()
    {
        Nome = "O necessário para matar um deus";
        Descricao = "Ned disse que nessa ilha tem um monte de *ADAMANTITA*. Vamos ter que levar um pouco pra ele.";
        RecompensaXp = 5000;
        Metas = new System.Collections.Generic.List<Meta>();
        Metas.Add(new MetaColeta(this, "Adamantita", "Deem um jeito de trazer 10 cristais de adamantita", false, 0, 10));
        Metas.Add(new MetaExploracao(this, "Tragam-me o material, estou esperando na minha forja", false, 0, 1));
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