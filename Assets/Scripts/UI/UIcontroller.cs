using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public static UIcontroller instance; // Singleton opcional, caso necessário
    public GameObject tutorial; // Referência ao tutorial
    public GameObject creditos; // Referência ao menu de configurações
    public GameObject PauseMenu; // Referência ao menu de pausa
    public bool pausado = false; // Indica se o jogo está pausado

    void Start()
    {
        InicializarTutorial();
        InicializarConfig();
    }

    private void InicializarTutorial()
    {
        if (tutorial != null)
            tutorial.SetActive(false); // Garante que o tutorial comece desativado
    }

    private void InicializarConfig()
    {
        if (creditos != null)
            creditos.SetActive(false); // Garante que o menu de configurações comece desativado
    }

    void Update()
    {
        // Verifica se as teclas ESC ou P foram pressionadas
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && PauseMenu != null)
        {
            if (pausado)
            {
                ResumeGame(); // Retoma o jogo
            }
            else
            {
                PauseGame(); // Pausa o jogo
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Pausa o tempo do jogo
        PauseMenu.SetActive(true); // Ativa o menu de pausa
        pausado = true; // Atualiza o estado
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Retoma o tempo do jogo
        PauseMenu.SetActive(false); // Desativa o menu de pausa
        pausado = false; // Atualiza o estado
    }

    public void ExitGame()
    {
        Application.Quit(); // Fecha o jogo (funciona somente no build)
    }

    public void Creditos()
    {
        if (creditos != null)
            creditos.SetActive(true); // Ativa o menu de configurações
    }

    public void TrocaCena(string cena)
    {
        Time.timeScale = 1; // Garante que o tempo esteja normal antes de trocar de cena
        SceneManager.LoadScene(cena); // Troca para a cena especificada
    }

    public void Tutorial()
    {
        if (tutorial != null)
            tutorial.SetActive(true); // Ativa o tutorial
    }

    public void Desactive()
    {
        if (tutorial != null)
            tutorial.SetActive(false); // Desativa o tutorial
        if (creditos != null)
            creditos.SetActive(false); // Desativa o menu de configurações
    }
}
