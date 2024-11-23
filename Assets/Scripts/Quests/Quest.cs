using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    //public Character player;
    public List<Meta> Metas;
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int RecompensaXp { get; set; }
    public int RecompensaMoedas { get; set; }
    public bool Completa { get; set; }

    public void ConferirMetas()
    {
        //Confere se todas as metas foram cumpridas e, caso verdadeiro irá recompensar o jogador
        Completa = (Metas.All(m => m.completa));

        if (Completa)
        {
            Debug.Log(Nome + " Concluída");
            Recompensar();
        }
    }
    void Recompensar()
    {
        if (RecompensaMoedas != null && RecompensaMoedas != 0)
        {
            Debug.Log("Recompensa dada");
            //Este método irá conceder a recompensa em moedas ao jogador, quando a quest for completa
            //player.GanharMoedas(RecompensaMoedas);
        }
    }
}