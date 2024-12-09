using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidade de movimento normal
    public float sprintSpeed = 8f;   // Velocidade ao correr
    private Rigidbody rb;
    private bool canMove = true;     // Controla se o jogador pode se mover

    private CharacterController controller;
    float gravity = 50;
    private float rot;
    private float rotSpeed = 200;
    private Vector3 movedirection;
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
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (canMove) // Executa os comandos somente se puder se mover
        {
            Move();
        }

        animator.enabled = true;
        AnimationMoviment();
    }
    private void Move()
    {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    movedirection = Vector3.forward * sprintSpeed;
                }
                else
                {
                    movedirection = Vector3.forward * moveSpeed;
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                movedirection = Vector3.zero;
            }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        movedirection.y -= 50;
        movedirection = transform.TransformDirection(movedirection);

        controller.Move(movedirection * Time.deltaTime);
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
