using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Arraste o objeto do jogador para essa vari�vel no inspector
    public Vector3 offsetPosition = new Vector3(0, 7.47f, -8.41f); // Defina o offset da c�mera em rela��o ao jogador
    public Vector3 offsetRotation = new Vector3(29.026f, 0f, 0f); // Defina a rota��o fixa da c�mera

    void LateUpdate()
    {
        // Atualiza a posi��o da c�mera para ficar na posi��o correta em rela��o ao jogador
        transform.position = player.position + offsetPosition;

        // Aplica a rota��o fixa � c�mera
        transform.rotation = Quaternion.Euler(offsetRotation);
    }
}
