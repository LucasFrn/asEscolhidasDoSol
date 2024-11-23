using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta
{
    public string Descricao { get; set; }
    public bool Completa { get; set; }
    public int Atingida { get; set; }
    public int Desejada { get; set; }

    public virtual void Iniciar()
    {

    }
    public void Conferir()
    {
        if (Atingida>=Desejada)
        {
            Completar();
        }
    }
    public void Completar()
    {
        Completa = true;
    }
}
