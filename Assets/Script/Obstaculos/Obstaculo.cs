using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private bool isActive = true;

    public AudioClip hitClip;

    [SerializeField]
    private AudioSource source;


    private void Start()
    {
        source = GameObject.Find("EffectSource").GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Personaje>().isInvincible == false)
        {
            if (isActive)
            {
                Debug.Log("Choque con: " + collision.name);
                Personaje.Instance.RecieveDamage();
                source.PlayOneShot(hitClip);
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
