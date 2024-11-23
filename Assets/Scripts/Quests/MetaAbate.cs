using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaAbate : Meta
{
    public int IDMonstro { get; set; }

    public MetaAbate(int idMonstro, string descricao,bool completa, int atingida, int desejada)
    {
        IDMonstro = idMonstro;
        Descricao = descricao;
        Completa = completa;
        Atingida = atingida;
        Desejada = desejada;
    }
    public override void Iniciar()
    {
        base.Iniciar();
        //TODO Observar com Angelo como está o sistema de eventos do combate, é necessário um evento das mortes
        //dos inimigos, que irá chamar a função abate aqui
    }
    public void Abate(Character monstro)
    {
        if (monstro.energia == IDMonstro)//TODO - Angelo - Criar campo de id que separa os monstros por tipo
        {
            Atingida ++;
            Conferir();
        }
    }
}
