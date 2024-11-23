using UnityEngine;

public class MonsterPackAI : MonoBehaviour
{
    public Transform player; // Refer�ncia ao jogador
    public GameObject[] monsters; // Array com os 3 monstros da matilha
    public float detectionRadius = 5f; // Dist�ncia para come�ar a seguir
    public float stopChasingDistance = 7f; // Dist�ncia para parar de seguir
    public float movementSpeed = 3.5f; // Velocidade de movimento dos monstros

    private bool isChasing = false;
    private Vector3[] startPositions;

    void Start()
    {
        startPositions = new Vector3[monsters.Length];
        for (int i = 0; i < monsters.Length; i++)
        {
            startPositions[i] = monsters[i].transform.position; // Armazena as posi��es iniciais dos monstros
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, GetClosestMonster().transform.position);

        if (distanceToPlayer <= detectionRadius && !isChasing)
        {
            // Quando um monstro detecta o jogador, todos come�am a perseguir
            isChasing = true;
        }
        else if (distanceToPlayer > stopChasingDistance && isChasing)
        {
            // Jogador est� longe, a matilha para de seguir
            isChasing = false;
        }

        if (isChasing)
        {
            // Move todos os monstros em dire��o ao jogador
            foreach (GameObject monster in monsters)
            {
                MoveTowardsPlayer(monster);
            }
        }
        else
        {
            // Se os monstros pararem de seguir, voltam para suas posi��es iniciais
            for (int i = 0; i < monsters.Length; i++)
            {
                MoveBackToStart(monsters[i], startPositions[i]);
            }
        }
    }

    // Encontra o monstro mais pr�ximo do jogador
    GameObject GetClosestMonster()
    {
        GameObject closestMonster = monsters[0];
        float closestDistance = Vector3.Distance(player.position, closestMonster.transform.position);

        foreach (GameObject monster in monsters)
        {
            float distance = Vector3.Distance(player.position, monster.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestMonster = monster;
            }
        }
        return closestMonster;
    }

    // Move o monstro em dire��o ao jogador
    void MoveTowardsPlayer(GameObject monster)
    {
        Vector3 direction = (player.position - monster.transform.position).normalized;
        monster.transform.position += direction * movementSpeed * Time.deltaTime;
    }

    // Faz o monstro voltar � sua posi��o inicial
    void MoveBackToStart(GameObject monster, Vector3 startPosition)
    {
        if (monster.transform.position != startPosition)
        {
            Vector3 direction = (startPosition - monster.transform.position).normalized;
            monster.transform.position += direction * movementSpeed * Time.deltaTime;
        }
    }

    // Desenhar as �reas de detec��o no editor
    void OnDrawGizmosSelected()
    {
        if (monsters != null)
        {
            Gizmos.color = Color.red;
            foreach (GameObject monster in monsters)
            {
                Gizmos.DrawWireSphere(monster.transform.position, detectionRadius);
            }

            Gizmos.color = Color.blue;
            foreach (GameObject monster in monsters)
            {
                Gizmos.DrawWireSphere(monster.transform.position, stopChasingDistance);
            }
        }
    }
}
