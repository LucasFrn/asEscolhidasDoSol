using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Arraste o objeto do jogador para essa variável no inspector
    public Vector3 offsetPosition = new Vector3(0, 7.47f, -8.41f); // Defina o offset da câmera em relação ao jogador
    public Vector3 offsetRotation = new Vector3(29.026f, 0f, 0f); // Defina a rotação fixa da câmera

    void LateUpdate()
    {
        // Atualiza a posição da câmera para ficar na posição correta em relação ao jogador
        transform.position = player.position + offsetPosition;

        // Aplica a rotação fixa à câmera
        transform.rotation = Quaternion.Euler(offsetRotation);
    }
}
