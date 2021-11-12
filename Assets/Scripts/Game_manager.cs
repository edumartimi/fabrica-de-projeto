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

    // Start is called before the first frame update

    private void Awake()
    {
        pausado = false;
        painel.SetActive(false);
        AudioListener.pause = false;
        volume.value = 1;
        Time.timeScale = 1;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
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
}
