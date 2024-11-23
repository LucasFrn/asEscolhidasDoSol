using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Meta> Metas { get; set; } = new List<Meta>();
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int RecompensaXp { get; set; }
    public int RecompensaMoedas { get; set; }
    public bool Completa { get; set; }

    public void ConferirMetas()
    {
        Completa = (Metas.All(g => g.Completa));
        if (Completa) Recompensar();
    }
    void Recompensar()
    {
        if (RecompensaMoedas != null && RecompensaMoedas != 0)
        {
            //InventarioController.Instance.DarMoedas(RecompensaMoedas)
        }
    }


}
