using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerOnCollision : MonoBehaviour
{
    // Nome da cena espec�fica para esse monstro
    [SerializeField]
    private string sceneName;

    // M�todo chamado automaticamente quando h� uma colis�o com outro objeto
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
