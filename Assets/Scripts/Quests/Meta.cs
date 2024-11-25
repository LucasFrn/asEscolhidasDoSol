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
        //Ex.: A verificação da meta "Mate 50 slimes" deve se preocupar se o número de slimes abatidos é maior
        // ou igual à 50 para retornar true.
        if (atingida >= desejada) Completar();
    }
    public void Completar()
    {
        //Marca a meta atual como completa e verifica a situação de todas as metas da quest em que esta meta
        //está situada
        completa = true;
        Debug.Log(descricao + " Concluída");
        quest.ConferirMetas();
    }
}
