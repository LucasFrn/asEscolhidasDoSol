using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController controller;
    public AudioMixer MeuMixer;
    public AudioSource MinhaMusica;
    public AudioClip [] MeusSons;
    void Awake()
    {
        if (controller == null)
        {
            controller= this;
        }
        else
        {        
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }
    public void TrocarMusicaAtiva(string cena)
    {
        Debug.Log("Musica");
        MinhaMusica.Stop();
        switch (cena)
        {
            case "Menu":
                MinhaMusica.clip = MeusSons[0];          
                break;
            case "Game": 
                MinhaMusica.clip= MeusSons[1];
                break;
            case "Milton":
                MinhaMusica.clip = MeusSons[2];
                break;
            case "Vitoria":
                MinhaMusica.clip = MeusSons[3];
                break;
            case "Derrota":
                MinhaMusica.clip = MeusSons[4];
                break;
            default:
                break;
        }

        MinhaMusica.Play();
    }

    public void MudarVolumeGeral(float valor)
    {
        if (valor <= -19)
        {
            MeuMixer.SetFloat("VolMaster", -80F);

        }
        else
        {
            MeuMixer.SetFloat("VolMaster", valor);
        }
    }
    public void MudarVolumeMusica(float valor)
    {
        if (valor <= -19)
        {
            MeuMixer.SetFloat("VolMusica", -80F);

        }
        else
        {
            MeuMixer.SetFloat("VolMusica", valor);
        }
    }
    public void MudarVolumeEfeitos(float valor)
    {
        if (valor <= -19)
        {
            MeuMixer.SetFloat("VolEfeitos", -80F);

        }
        else
        {
            MeuMixer.SetFloat("VolEfeitos", valor);
        }
    }
    
}
