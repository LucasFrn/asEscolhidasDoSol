using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudioTrigger : MonoBehaviour
{
    public AudioSource footstepAudio; // Arraste o AudioSource no Inspector
    public CharacterController characterController; // Refer�ncia ao componente do personagem (ou Rigidbody)

    private bool isPlayerInArea = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInArea = false;
            if (footstepAudio.isPlaying)
            {
                footstepAudio.Stop(); // Para o �udio ao sair da �rea
            }
        }
    }

    private void Update()
    {
        if (isPlayerInArea && characterController != null)
        {
            // Verifica se o personagem est� se movendo
            if (characterController.velocity.magnitude > 0.1f) // Ajuste o valor conforme necess�rio
            {
                if (!footstepAudio.isPlaying)
                {
                    footstepAudio.Play(); // Toca o �udio apenas se ele n�o estiver tocando
                }
            }
            else
            {
                if (footstepAudio.isPlaying)
                {
                    footstepAudio.Stop(); // Para o �udio se o personagem parar de andar
                }
            }
        }
    }
}
