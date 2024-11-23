using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SistemaDeTurnos : MonoBehaviour
{
    // Lista de personagens no combate
    private List<Character> personagensEmBatalha = new List<Character>();

    // Timeline de turnos
    public List<Character> timeline = new List<Character>();

    // Quantidade máxima de turnos na timeline
    public int maxTimelineSize = 9;

    void Start()
    {
        // Inicializa personagens presentes na cena (inimigos e aliados)
        InicializarPersonagens();

        // Atualiza a timeline no começo do combate
        AtualizarTimeline();
    }

    // Inicializa todos os personagens da cena
    void InicializarPersonagens()
    {
        // Aqui, busca todos os personagens na cena usando a tag "Personagem"
        GameObject[] personagens = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject go in personagens)
        {
            Character personagem = go.GetComponent<Character>();
            if (personagem != null)
            {
                personagensEmBatalha.Add(personagem);
            }
        }
    }

    public void InicializarPersonagensNaCena()
    {
        // Busca todos os personagens na cena que possuem o script "Character"
        Character[] personagens = FindObjectsOfType<Character>();

        // Ordena os personagens pela velocidade, do maior para o menor
        List<Character> personagensOrdenados = new List<Character>(personagens);
        personagensOrdenados.Sort((p1, p2) => p2.velocidade.CompareTo(p1.velocidade));

        // Preenche a timeline com os personagens, repetindo-os se necessário
        timeline.Clear();
        for (int i = 0; i < maxTimelineSize; i++)
        {
            Character personagemParaAdicionar = personagensOrdenados[i % personagensOrdenados.Count];
            timeline.Add(personagemParaAdicionar);
        }
    }

    // Atualiza a timeline para organizar por velocidade
    public void AtualizarTimeline()
    {
        // Ordena os personagens em batalha pela velocidade, em ordem decrescente
        List<Character> personagensOrdenados = personagensEmBatalha.OrderByDescending(p => p.velocidade).ToList();

        // Preenche a timeline com os personagens, repetindo-os se necessário
        timeline.Clear();
        for (int i = 0; i < maxTimelineSize; i++)
        {
            Character personagemParaAdicionar = personagensOrdenados[i % personagensOrdenados.Count];
            timeline.Add(personagemParaAdicionar);
        }
    }

    public void ExecutarTurno()
    {
        if (timeline.Count > 0)
        {
            Character personagemAtual = timeline[0];

            if (personagemAtual.isAlly)
            {
                // Ativar ActionBar para o jogador selecionar uma ação
                FindObjectOfType<ActionBarUI>().ShowActionBar(true);
            }
            else
            {
                // Inimigo aguarda um pouco antes de atacar automaticamente
                StartCoroutine(InimigoExecutaAposAtraso(personagemAtual));
            }
        }
    }

    private IEnumerator InimigoExecutaAposAtraso(Character inimigo)
    {
        // Tempo de espera antes do inimigo atacar
        yield return new WaitForSeconds(1.5f);

        // Inimigo ataca automaticamente um aliado aleatório
        AtacarAleatoriamente(inimigo);
        FinalizarTurno();
    }

    private void IniciarAcaoInimigo(Character inimigo)
    {
        // Inimigo ataca automaticamente
        Character alvo = EscolherAlvoInimigo();
        if (alvo != null)
        {
            float dano = inimigo.ataque;
            alvo.AtualizaVida(-dano);
        }

        // Após a ação do inimigo, finaliza o turno
        FinalizarTurno();
    }
    private Character EscolherAlvoInimigo()
    {
        // Cria uma lista de aliados vivos
        List<Character> aliadosVivos = new List<Character>();

        // Varre a timeline para encontrar aliados (personagens com isAlly = true)
        foreach (Character personagem in timeline)
        {
            if (personagem.isAlly && personagem.vidaAtual > 0) // Apenas aliados vivos são considerados
            {
                aliadosVivos.Add(personagem);
            }
        }

        // Se houver aliados vivos, seleciona um aleatório
        if (aliadosVivos.Count > 0)
        {
            int indiceAleatorio = Random.Range(0, aliadosVivos.Count);
            return aliadosVivos[indiceAleatorio];
        }

        // Se nenhum aliado estiver vivo, retorna null
        return null;
    }

    private void AtacarAleatoriamente(Character atacante)
    {
        // Selecionar aleatoriamente um dos aliados
        List<Character> aliados = personagensEmBatalha.Where(p => p.isAlly).ToList();
        if (aliados.Count > 0)
        {
            Character alvo = aliados[Random.Range(0, aliados.Count)];
            // Calcular o dano e aplicar ao alvo
            float dano = atacante.ataque;
            alvo.AtualizaVida(-dano);
        }
    }

    public void FinalizarTurno()
    {
        if (timeline.Count > 0)
        {
            // Remove o personagem que acabou de agir e coloca ele no final da fila
            Character personagemAtual = timeline[0];
            timeline.RemoveAt(0);
            timeline.Add(personagemAtual);

            // Atualiza a UI para refletir a nova ordem
            FindObjectOfType<UI_Turnos>().AtualizarUI();

            // Executa o próximo turno
            ExecutarTurno();
        }
    }

    private IEnumerator EsperarAntesDeExecutarProximoTurno()
    {
        yield return new WaitForSeconds(0.1f);  // Aguarda um décimo de segundo
        ExecutarTurno();
    }

    // Método para modificar a velocidade de um personagem e recalcular a timeline
    public void ModificarVelocidade(Character personagem, int novaVelocidade)
    {
        personagem.velocidade = novaVelocidade;

        // Recalcula a timeline sempre que houver uma mudança de velocidade
        AtualizarTimeline();
    }
    public void RemoverPersonagem(Character personagem)
    {
        // Remove o personagem da lista de batalha
        personagensEmBatalha.Remove(personagem);

        // Remove o personagem da timeline, se ele estiver presente
        timeline.Remove(personagem);
    }
}
