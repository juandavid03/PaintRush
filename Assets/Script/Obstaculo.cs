using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private bool isActive = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("Choque con: " + collision.name);
            if (collision.gameObject.CompareTag("Player"))
            {
                if (isActive)
                {
                    Personaje.Instance.RecieveDamage();
                    this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
       
    }

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

}
