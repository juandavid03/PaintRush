using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Personaje : MonoBehaviour
{
    private static Personaje instance = null;

    // Game Instance Singleton
    public static Personaje Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }
    //private GameObject personaje;

    private Rigidbody2D rbody;

    public float force;

    [SerializeField]
    private int health = 1;

    [SerializeField]
    private float timeHealth = 5;

    private int layerMask = 8;
    private int layerMaskTest = 9;
    private float points = 0;
    private int invincibilidadDisponibles;
    private int tiempoLentoDisponibles;
    public bool isPaused = false;

    public Text textPoints;

    public float Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public bool IsPaused
    {
        get
        {
            return isPaused;
        }
        set
        {
            isPaused = value;
        }
    }
    // Use this for initialization
    void Start ()
    {
        
        rbody = this.gameObject.GetComponent<Rigidbody2D>();
        textPoints = GameObject.Find("textPoints").GetComponent<Text>();
        invincibilidadDisponibles = PlayerPrefs.GetInt("TiempoLento");
        tiempoLentoDisponibles = PlayerPrefs.GetInt("Invincibilidad");
        Debug.Log("Invincibilidad: " + invincibilidadDisponibles);
        Debug.Log("Tiempo Lento: " + tiempoLentoDisponibles);

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Todas las funcionalidades del update, van dentro de este if, para qu funcione cuando no estan pausadas.
        if (!isPaused)
        {
            timeHealth -= Time.deltaTime;
            var vel = new Vector2(1, rbody.velocity.y);
            rbody.velocity = vel.normalized * force;
            ActualizarPuntaje();
            Debug.Log("Health: " + Health);
            if (timeHealth < 0)
            {
                timeHealth = 10;
                if (Health < 3)
                {
                    health++;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                LanzarRayo("circle");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                LanzarRayo("polygon");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                LanzarRayo("square");
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {

                LanzarRayo("triangle");
            }
        }
        else if (isPaused)
        {
            rbody.velocity = Vector2.zero;
        }
	}

    public void RecieveDamage()
    {
        Health = Health - 1;    
    }

    public void LanzarRayo(string forma)
    {
        Debug.LogWarning("Forma: " + forma);
        switch (forma)
        {
            
            case "circle":
                {
                    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, Mathf.Infinity);
                    if (hit)
                    {
                        
                        if (hit.collider.gameObject.CompareTag("ObstacleCircle"))
                        {
                            Debug.Log("Desactive el circulito");
                            hit.collider.gameObject.GetComponent<Obstaculo>().IsActive = false;
                        }
                    }
                    break;
                }
            case "polygon":
                {
                    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, Mathf.Infinity);
                    if (hit)
                    {
                        if (hit.collider.gameObject.tag == "ObstaclePolygon")
                        {
                            Debug.Log("Desactive el poligono");
                            hit.collider.gameObject.GetComponent<Obstaculo>().IsActive = false;
                        }
                    }
                    break;
                }
            case "square":
                {
                    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, Mathf.Infinity, layerMask);
                    if (hit)
                    {
                  
                        if (hit.collider.gameObject.tag == "ObstacleSquare")
                        {
                            Debug.Log("Desactive el square");
                            hit.collider.gameObject.GetComponent<Obstaculo>().IsActive = false;
                        }
                    }
                    break;
                }
            case "triangle":
                {
                    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, Mathf.Infinity, layerMask);
                    if (hit)
                    {
                     
                        if (hit.collider.gameObject.tag == "ObstacleTriangle")
                        {
                            Debug.Log("Desactive el triangle");
                            hit.collider.gameObject.GetComponent<Obstaculo>().IsActive = false;
                        }
                    }
                    break;
                }
        }
    }

    public void ActualizarPuntaje()
    {
        if (Health == 3)
            Points += 3;
        if (Health == 2)
            Points += 2;
        if (Health == 1)
            Points += 1 ;
        textPoints.text = "Puntos: " + Points.ToString();
    }
}
