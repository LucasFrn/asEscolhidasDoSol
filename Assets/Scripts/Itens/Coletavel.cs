using System.Collections;
using TMPro;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public string nome; 
    private bool podeColetar = false;
    public TextMeshProUGUI txtInteracao;
    public TextMeshProUGUI txtColeta;
    public GameEvent onItemColetado;

    private void Start()
    {
        txtColeta.enabled = false;
        txtInteracao.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (podeColetar)
            {
                StartCoroutine(Coletar());
            }
        }
    }
    IEnumerator Coletar()
    {
        onItemColetado.Raise(this, nome);
        txtColeta.text = nome+" x1";
        txtColeta.enabled = true;
        yield return new WaitForSeconds(2);
        txtColeta.enabled = false;
        txtInteracao.enabled = false;
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            txtInteracao.text = "Pressione E para coletar";
            txtInteracao.enabled = true;
            podeColetar = true;
        }
       
    }
    private void OnTriggerExit(Collider other) 
    {
        
        if (other.gameObject.tag == "Player")
        {
            txtInteracao.enabled = false;
            podeColetar = false;
        }
    }
}
