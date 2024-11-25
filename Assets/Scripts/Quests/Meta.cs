using UnityEngine;

public class Meta
{
    public Quest quest;
    public string descricao { get; set; }
    public bool completa { get; set; }
    public int atingida { get; set; }
    public int desejada { get; set; }

    public virtual void Iniciar() { }
    public void Conferir()
    {
        //Verifica se o jogador conseguiu atingir o objetivo 
        //Ex.: A verifica��o da meta "Mate 50 slimes" deve se preocupar se o n�mero de slimes abatidos � maior
        // ou igual � 50 para retornar true.
        if (atingida >= desejada) Completar();
    }
    public void Completar()
    {
        //Marca a meta atual como completa e verifica a situa��o de todas as metas da quest em que esta meta
        //est� situada
        completa = true;
        Debug.Log(descricao + " Conclu�da");
        quest.ConferirMetas();
    }
}
