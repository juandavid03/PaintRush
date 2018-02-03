using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
