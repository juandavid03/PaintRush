using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private bool isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            
            if (collision.gameObject.CompareTag("Player"))
            {
                if (isActive)
                {
                    Debug.Log("Choque con: " + collision.name);
                    Personaje.Instance.RecieveDamage();   
                }
            }
       
    }

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    private void Update()
    {
        if (!IsActive)
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

}
