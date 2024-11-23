using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaExploracao : Meta
{
    
    public MetaExploracao(Quest quest, string descricao, bool completa, int atingida, int desejada)
    {
        this.quest = quest;
        base.descricao = descricao;
        base.completa = completa;
        base.atingida = atingida;
        base.desejada = desejada;
    }
}
