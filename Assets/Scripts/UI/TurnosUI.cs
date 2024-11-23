using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Turnos : MonoBehaviour
{
    // Refer�ncia ao script do sistema de turnos
    public SistemaDeTurnos sistemaDeTurnos;

    // Lista de imagens que representam os slots da timeline
    public List<Image> slotsTimeline;

    // Sprite padr�o quando n�o h� personagem no slot
    public Sprite emptySlotSprite;

    void Start()
    {
        // Inicializa a timeline assim que a cena come�a
        MontarTimeline();
    }

    // Monta a timeline automaticamente quando a cena � carregada
    public void MontarTimeline()
    {
        // Inicializa a timeline pegando os personagens da cena
        sistemaDeTurnos.InicializarPersonagensNaCena();

        // Atualiza a UI logo ap�s montar a timeline
        AtualizarUI();
    }

    // Atualiza a UI da timeline com base na ordem dos personagens
    public void AtualizarUI()
    {
        // Limpa os slots da timeline
        for (int i = 0; i < slotsTimeline.Count; i++)
        {
            if (i < sistemaDeTurnos.timeline.Count)
            {
                // Pega o personagem na posi��o atual da timeline
                Character personagem = sistemaDeTurnos.timeline[i];

                // Atualiza o �cone do personagem no slot correspondente
                slotsTimeline[i].sprite = personagem.GetComponent<PersonagemUI>().iconePersonagem;
                slotsTimeline[i].color = Color.white;  // Reseta a cor para garantir visibilidade
            }
            else
            {
                // Se n�o h� personagem para o slot, usa o sprite vazio e torna o slot invis�vel
                slotsTimeline[i].sprite = emptySlotSprite;
                slotsTimeline[i].color = Color.clear;
            }
        }
    }
}
