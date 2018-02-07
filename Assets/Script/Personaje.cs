using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Personaje : MonoBehaviour
{

    private GameObject personaje;

    private Rigidbody2D rbody;

    public float force;

    // Use this for initialization
    void Start ()
    {
        personaje = GameObject.Find("Personaje");
        rbody = this.gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.timeScale != 0)
        {
            var vel = new Vector2(1, rbody.velocity.y);
            rbody.velocity = vel.normalized * force;
            Debug.Log(rbody.velocity);

        }

	}
}
