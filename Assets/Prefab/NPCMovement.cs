using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform[] patrolPoints; // Pontos de patrulha para o NPC seguir
    public float moveSpeed = 3f; // Velocidade de movimento
    public float rotationSpeed = 5f; // Velocidade de rotação para virar para o alvo
    private Animator animator;
    private int currentPointIndex = 0; // Índice do ponto de patrulha atual

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtém o componente Animator
    }

    void Update()
    {
        // Se houver pontos de patrulha configurados
        if (patrolPoints.Length > 0)
        {
            MoveNPC(); // Chama o movimento do NPC
        }
    }

    void MoveNPC()
    {
        // Movimento do NPC em direção ao próximo ponto
        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector3 direction = targetPoint.position - transform.position;
        direction.y = 0; // Ignora o eixo Y para manter o NPC nivelado

        // Gira o NPC em direção ao ponto de patrulha
        if (direction.magnitude > 0.1f)
        {
            // Faz o NPC girar suavemente em direção ao alvo
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move o NPC em direção ao ponto
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

            // Ativa a animação de caminhada
            animator.SetBool("isWalking", true);
        }
        else
        {
            // Para a animação quando o NPC chegar ao ponto
            animator.SetBool("isWalking", false);

            // Aguardar um momento ou trocar para o próximo ponto
            Invoke("GoToNextPoint", 2f); // Delay antes de ir para o próximo ponto
        }
    }

    void GoToNextPoint()
    {
        // Atualiza o índice para o próximo ponto de patrulha
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }
}
