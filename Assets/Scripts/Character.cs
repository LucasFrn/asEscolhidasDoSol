using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Atributos do Personagem
    public float vidaAtual;
    public float vidaMaxima;
    public int energia;
    public int velocidade;
    public float ataque;
    public float magia;
    public int defesa;
    public bool isAlly;
    public GameObject characterStatus;

    public void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void AtualizaVida(float valor)
    {
        vidaAtual += valor;

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            SistemaDeTurnos sistemaDeTurnos = FindObjectOfType<SistemaDeTurnos>();
            sistemaDeTurnos.RemoverPersonagem(this);

            this.gameObject.SetActive(false);
            characterStatus.SetActive(false);
        }
        else if (vidaAtual >= vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }
    }
    public void InicializarPersonagem(int vida, int velocidade, int ataque, int magia, int defesa)
    {
        this.vidaMaxima = vida;
        this.energia = 0;
        this.velocidade = velocidade;
        this.ataque = ataque;
        this.magia = magia;
        this.defesa = defesa;
    }
    public void AumentarEnergia(int valor)
    {
        energia += valor;
        if (energia > 5)
        {
            energia = 5;
        }
    }
}
