using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStatusUI : MonoBehaviour
{
    public Slider barraDeVida;
    public Slider barraDeEnergia;
    public TextMeshProUGUI textoVida;
    public TextMeshProUGUI textoEnergia;
    public Character personagem;

    void Start()
    {
        barraDeVida.maxValue = personagem.vidaMaxima;
        barraDeEnergia.maxValue = 5;
        AtualizarUI();
    }

    void Update()
    {
        AtualizarUI();
    }

    void AtualizarUI()
    {
        barraDeVida.value = personagem.vidaAtual;
        barraDeEnergia.value = personagem.energia;

        textoVida.text = "Vida: " + barraDeVida.value + "/" + barraDeVida.maxValue;

        textoEnergia.text = "Energia: " + barraDeEnergia.value + "/" + barraDeEnergia.maxValue;
    }
}
