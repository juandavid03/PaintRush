using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject canvasPausa;
    public GameObject canvasUI;
    private bool isPaused;

    public void Awake()
    {
        canvasUI = GameObject.Find("CanvasUI");
        canvasPausa = GameObject.Find("CanvasPausa");
    }
    public void Start()
    {
        isPaused = false;
        canvasUI.SetActive(true);
        canvasPausa.SetActive(false);
    }
    public void Pausar()
    {
        isPaused = !isPaused;
    }

    public void Update()
    {
        if (isPaused)
        {
            Personaje.Instance.IsPaused = true;
            Time.timeScale = 0;
            canvasPausa.SetActive(true);
            canvasUI.SetActive(false);
        }
        else if (!isPaused)
        {
            Personaje.Instance.isPaused = false;
            Time.timeScale = 1;
            canvasPausa.SetActive(false);
            canvasUI.SetActive(true);
        }
    }
}
