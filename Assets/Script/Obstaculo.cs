using UnityEngine;

public class Obstaculo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("Choque con: " + collision.name);
            if (collision.gameObject.CompareTag("Player"))
            {
                Personaje.Instance.RecieveDamage();
            }
       
    }

}
