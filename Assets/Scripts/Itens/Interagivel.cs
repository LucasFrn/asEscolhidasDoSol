using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interagivel : MonoBehaviour
{
    public string nome;
    private bool podeInteragir = false;
    public TextMeshProUGUI txtInteracao;
    public GameEvent onItemColetado;

    private void Start()
    {
        txtInteracao.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (podeInteragir)
            {
                StartCoroutine(Interagir());
            }
        }
    }
    IEnumerator Interagir()
    {
        //onItemColetado.Raise(this, nome);
        yield return new WaitForSeconds(2);
        txtInteracao.enabled = false;
        SceneManager.LoadScene(4);
    }
    private void OnTriggerEnter(Collider other)
    {
        txtInteracao.text = "Pressione E para usar";
        if (other.gameObject.tag == "Player")
        {
            
            txtInteracao.enabled = true;
            podeInteragir = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            txtInteracao.enabled = false;
            podeInteragir = false;
        }
    }
}