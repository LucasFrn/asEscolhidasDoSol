using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerOnCollision : MonoBehaviour
{
    // Nome da cena específica para esse monstro
    [SerializeField]
    private string sceneName;

    // Método chamado automaticamente quando há uma colisão com outro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Carrega a cena especificada para este monstro
            SceneManager.LoadScene(sceneName);
        }
    }
}
