using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_manager : MonoBehaviour
{
    public bool pausado;
    public GameObject painel;
    private bool mutado;
    public Slider volume;
    private float qtdvolume;
    public GameObject gameover_painel;
    public GameObject gameover_painel2;
    private float tmpinicio;
    public GameObject iniciogame;
    public GameObject faltam_chaves;
    private float tmptxt;
    public GameObject UI_chaves;
    public GameObject menucontroles;
    public GameObject painel_pergaminho;
    public GameObject painel_venceu;

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
        UI_chaves.SetActive(true);
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

    public void lerpergaminho(string texto) 
    {
        painel_pergaminho.SetActive(true);
        Time.timeScale = 0;
    }


    public void voltarpergaminho(string texto)
    {
        painel_pergaminho.SetActive(false);
        Time.timeScale = 1;
    }

    public void pause()
    {
        Time.timeScale = 0;
        pausado = true;
        painel.SetActive(true);
        AudioListener.pause = true;
        UI_chaves.SetActive(false);
    }

    public void voltar()
    {
        Time.timeScale = 1;
        pausado = false;
        painel.SetActive(false);
        AudioListener.pause = false;
        UI_chaves.SetActive(true);
    }

    public void vocevenceu() 
    {
        painel_venceu.SetActive(true);
        Time.timeScale = 0;
    }


    public void menu1() 
    {
        menucontroles.SetActive(false);
        Time.timeScale = 1;
    }

    public void reiniciar()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
        pausado = false;
        painel.SetActive(false);
        AudioListener.pause = false;
        UI_chaves.SetActive(true);
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

    public void Game_over(int tipo) 
    {

        if (tipo == 1)
        {
            gameover_painel.SetActive(true);
            Time.timeScale = 0;
            pausado = true;
            AudioListener.pause = false;
            UI_chaves.SetActive(false);
        }
        else if (tipo == 0)
        {
            gameover_painel2.SetActive(true);
            Time.timeScale = 0;
            pausado = true;
            AudioListener.pause = false;
            UI_chaves.SetActive(false);
        }
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
