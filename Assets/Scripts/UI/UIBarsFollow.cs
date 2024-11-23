using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBarsFollow : MonoBehaviour
{
    // Referências para as barras de Vida e Energia
    public Transform target; // O alvo (personagem) que as barras seguirão
    public RectTransform barraVidaUI; // Referência para a barra de Vida
    public RectTransform barraEnergiaUI; // Referência para a barra de Energia
    public Vector3 offsetVida; // Offset para ajustar a posição da barra de Vida
    public Vector3 offsetEnergia; // Offset para ajustar a posição da barra de Energia
    public Camera mainCamera; // A câmera principal para converter coordenadas de mundo para tela

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void LateUpdate()
    {
        // Calcula a posição da barra de Vida na tela com o offset
        Vector3 screenPositionVida = mainCamera.WorldToScreenPoint(target.position + offsetVida);
        barraVidaUI.position = screenPositionVida;

        // Calcula a posição da barra de Energia na tela com o offset
        Vector3 screenPositionEnergia = mainCamera.WorldToScreenPoint(target.position + offsetEnergia);
        barraEnergiaUI.position = screenPositionEnergia;
    }
}
