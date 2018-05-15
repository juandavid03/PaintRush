using UnityEngine;
using System.Collections;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private bool isActive = true;

    public AudioClip hitClip;

    [SerializeField]
    private AudioSource source;

    private Color newColor;

    private Renderer obstacleRenderer;


    private void Awake()
    {
        obstacleRenderer = this.gameObject.GetComponent<Renderer>();   
    }
    private void Start()
    {
        source = GameObject.Find("EffectSource").GetComponent<AudioSource>();
        newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        obstacleRenderer.material.color = newColor;
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
