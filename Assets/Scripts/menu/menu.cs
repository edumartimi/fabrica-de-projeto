using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public void novoJogo()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void sair_do_jogo()
    {
        Application.Quit();
    }
}
