using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidade de movimento normal
    public float sprintSpeed = 8f;   // Velocidade ao correr
    private Rigidbody rb;
    private bool canMove = true;     // Controla se o jogador pode se mover

    private Animator animator;
    private float vZ = 0f;
    private float vX = 0f;

    public float aceleracao = 2f;
    public float desaceleracao = 2f;

    public float vMaxAndar = 0.5f;
    public float vMaxCorrer = 2.0f;

    private const string KEY_FRONTAL = "w";
    private const string KEY_TRAS = "s";
    private const string KEY_ESQUERDA = "a";
    private const string KEY_DIREITA = "d";
    private const string KEY_CORRER = "left shift";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove) // Executa os comandos somente se puder se mover
        {
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

            // Ajusta a rotação para a direção do movimento
            if (moveDirection != Vector3.zero)
            {
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                float snappedAngle = Mathf.Round(targetAngle / 90) * 90; // Ajusta para 90 graus
                transform.rotation = Quaternion.Euler(0, snappedAngle, 0);
            }

            Vector3 move = moveDirection * currentSpeed;
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }

        animator.enabled = true;
        AnimationMoviment();
    }

    private void AnimationMoviment()
    {
        bool frente = Input.GetKey(KEY_FRONTAL);
        bool tras = Input.GetKey(KEY_TRAS);
        bool esquerda = Input.GetKey(KEY_ESQUERDA);
        bool direita = Input.GetKey(KEY_DIREITA);
        bool correndo = Input.GetKey(KEY_CORRER);

        float vMaxAtual = correndo ? vMaxCorrer : vMaxAndar;

        // Atualizar velocidades com aceleração/desaceleração
        vZ = AtualizarVelocidade(vZ, frente, tras, vMaxAtual);
        vX = AtualizarVelocidade(vX, direita, esquerda, vMaxAtual);

        // Passar valores para o Animator
        animator.SetFloat("Z", vZ);
        animator.SetFloat("X", vX);
    }

    private float AtualizarVelocidade(float valorAtual, bool positivo, bool negativo, float velocidadeMaxima)
    {
        if (positivo)
        {
            valorAtual = Mathf.Min(valorAtual + Time.deltaTime * aceleracao, velocidadeMaxima);
        }
        else if (negativo)
        {
            valorAtual = Mathf.Max(valorAtual - Time.deltaTime * aceleracao, -velocidadeMaxima);
        }
        else
        {
            // Desaceleração suave quando não há entrada
            if (valorAtual > 0)
            {
                valorAtual = Mathf.Max(valorAtual - Time.deltaTime * desaceleracao, 0);
            }
            else if (valorAtual < 0)
            {
                valorAtual = Mathf.Min(valorAtual + Time.deltaTime * desaceleracao, 0);
            }
        }

        return valorAtual;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ramp")) // Verifica se tocou na rampa
        {
            canMove = false; // Desativa o movimento
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ramp")) // Verifica se saiu da rampa
        {
            canMove = true; // Reativa o movimento
        }
    }
}
