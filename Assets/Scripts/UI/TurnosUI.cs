using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Turnos : MonoBehaviour
{
    // Referência ao script do sistema de turnos
    public SistemaDeTurnos sistemaDeTurnos;

    // Lista de imagens que representam os slots da timeline
    public List<Image> slotsTimeline;

    // Sprite padrão quando não há personagem no slot
    public Sprite emptySlotSprite;

    void Start()
    {
        // Inicializa a timeline assim que a cena começa
        MontarTimeline();
    }

    // Monta a timeline automaticamente quando a cena é carregada
    public void MontarTimeline()
    {
        // Inicializa a timeline pegando os personagens da cena
        sistemaDeTurnos.InicializarPersonagensNaCena();

        // Atualiza a UI logo após montar a timeline
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
                // Pega o personagem na posição atual da timeline
                Character personagem = sistemaDeTurnos.timeline[i];

                // Atualiza o ícone do personagem no slot correspondente
                slotsTimeline[i].sprite = personagem.GetComponent<PersonagemUI>().iconePersonagem;
                slotsTimeline[i].color = Color.white;  // Reseta a cor para garantir visibilidade
            }
            else
            {
                // Se não há personagem para o slot, usa o sprite vazio e torna o slot invisível
                slotsTimeline[i].sprite = emptySlotSprite;
                slotsTimeline[i].color = Color.clear;
            }
        }
    }
}
