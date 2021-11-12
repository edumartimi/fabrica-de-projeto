using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour
{
    public bool pausado;
    public GameObject painel;
    private bool mutado;
    public Slider volume;
    private float qtdvolume;
    public GameObject gameover_painel;
    private float tmpinicio;
    public GameObject iniciogame;
    public GameObject faltam_chaves;
    private float tmptxt;

    // Start is called before the first frame update

    private void Awake()
    {
        pausado = false;
        gameover_painel.SetActive(false);
        painel.SetActive(false);
        AudioListener.pause = false;
        volume.value = 1;
        Time.timeScale = 1;
        faltam_chaves.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        tmptxt = tmptxt + Time.deltaTime;
        tmpinicio = tmpinicio + Time.deltaTime;
        if (tmpinicio < 7.5)
        {
            iniciogame.SetActive(true);
        }
        else 
        {
            iniciogame.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !pausado)
        {
            pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausado)
        {
            voltar();
        }
        if (pausado && !mutado) 
        {
            AudioListener.volume = volume.value;
        }

        if (tmptxt > 3) 
        {
            faltam_chaves.SetActive(false);
        }
    }

    public void pause()
    {
        Time.timeScale = 0;
        pausado = true;
        painel.SetActive(true);
        AudioListener.pause = true;
    }

    public void voltar()
    {
        Time.timeScale = 1;
        pausado = false;
        painel.SetActive(false);
        AudioListener.pause = false;
    }

    public void muteall()
    {
        if (!mutado)
        {
            AudioListener.volume = 0;
            mutado = true;
        }
        else 
        {
            AudioListener.volume = 1;
            mutado = false;
        }
    }

    public void voltar_ao_menu() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void Game_over() 
    {
        gameover_painel.SetActive(true);
        Time.timeScale = 0;
        pausado = true;
        AudioListener.pause = false;
    }

    public void Game_win() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void faltamchaves() 
    {
        faltam_chaves.SetActive(true);
        tmptxt = 0;
    }
}
