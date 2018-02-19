using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private MenuManager manager;
	// Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Personaje.Instance.Health <= 0)
        {
            Perder();
        }
	}

    private void Perder()
    {
        manager.LoadScene("MainMenu");
    }
}
