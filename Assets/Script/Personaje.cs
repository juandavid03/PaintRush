using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    private GameObject personaje;
	// Use this for initialization
	void Start ()
    {
        personaje = GameObject.Find("Personaje");
	}
	
	// Update is called once per frame
	void Update ()
    {
        personaje.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
	}
}
