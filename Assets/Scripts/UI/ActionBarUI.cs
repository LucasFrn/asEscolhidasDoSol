using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBarUI : MonoBehaviour
{
    // Referências para os painéis de UI
    public GameObject actionBar;
    public GameObject skillBar;

    void Start()
    {
        // Garantir que a barra de ações esteja ativa e a de habilidades desativada inicialmente
        actionBar.SetActive(true);
        skillBar.SetActive(false);
    }

    // Método para ativar a barra de habilidades e desativar a barra de ações
    public void ShowSkillsBar()
    {
        actionBar.SetActive(false);
        skillBar.SetActive(true);
    }

    // Método para voltar para a barra de ações
    public void ShowActionBar(bool valor)
    {
        actionBar.SetActive(valor);
        skillBar.SetActive(false);
    }
    public void OnAtaqueBasico()
    {
        StartCoroutine(SelecionarInimigoParaAtaque());
    }

    private IEnumerator SelecionarInimigoParaAtaque()
    {
        // Aguarda até que o jogador selecione um inimigo
        bool inimigoSelecionado = false;
        Character inimigoAlvo = null;

        while (!inimigoSelecionado)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Character possivelInimigo = hit.collider.GetComponent<Character>();
                    if (possivelInimigo != null && !possivelInimigo.isAlly)
                    {
                        inimigoAlvo = possivelInimigo;
                        inimigoSelecionado = true;
                    }
                }
            }
            yield return null; // Espera um frame antes de continuar o loop
        }

        // Quando o inimigo for selecionado, realiza o ataque
        if (inimigoAlvo != null)
        {
            Character personagemAtual = FindObjectOfType<SistemaDeTurnos>().timeline[0];
            float dano = personagemAtual.ataque;
            inimigoAlvo.AtualizaVida(-dano);

            // Após realizar o ataque, finaliza o turno do aliado
            FindObjectOfType<SistemaDeTurnos>().FinalizarTurno();
        }
    }
}
