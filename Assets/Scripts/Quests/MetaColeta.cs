using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaColeta : Meta
{
    public string nomeItem { get; set; }
    public MetaColeta(Quest quest, string nomeItem, string descricao, bool completa, int atingida, int desejada)
    {
        this.quest = quest;
        this.nomeItem = nomeItem;
        base.descricao = descricao;
        base.completa = completa;
        base.atingida = atingida;
        base.desejada = desejada;
    }
}
