using UnityEngine;

public class Caixa : MonoBehaviour
{
    private Rigidbody rb;   // Refer�ncia ao Rigidbody da caixa

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Verifica se o Rigidbody foi encontrado
        if (rb == null)
        {
            Debug.LogError("Rigidbody n�o encontrado! Certifique-se de que a caixa tenha um Rigidbody.");
        }
        else
        {
            rb.isKinematic = true; // Come�a como kinematic
            rb.mass = 1000;        // Define a massa como 1000
        }
    }

    void Update()
    {
        // Detecta se a tecla "E" est� sendo pressionada
        if (Input.GetKey(KeyCode.E) && rb != null)
        {
            rb.isKinematic = false; // Desliga o kinematic da caixa enquanto E est� pressionado
        }
        else if (rb != null)
        {
            rb.isKinematic = true; // Liga o kinematic da caixa quando E n�o est� pressionado
        }
    }
}
