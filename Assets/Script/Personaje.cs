using UnityEngine;

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
    private int health = 3;

    [SerializeField]
    private float timeHealth = 5;

    private int layerMask = 8;


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

    // Use this for initialization
    void Start ()
    {
        //personaje = GameObject.Find("Personaje");
        rbody = this.gameObject.GetComponent<Rigidbody2D>();

       
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Todas las funcionalidades del update, van dentro de este if, para qu funcione cuando no estan pausadas.
        if (Time.timeScale != 0)
        {
            timeHealth -= Time.deltaTime;
            var vel = new Vector2(1, rbody.velocity.y);
            rbody.velocity = vel.normalized * force;
            //Debug.Log(rbody.velocity);
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
                Debug.LogError("Hundí 1");
                LanzarRayo(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.LogError("Hundí 2");
                LanzarRayo(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.LogError("Hundí 3");
                LanzarRayo(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.LogError("Hundí 4");
                LanzarRayo(4);
            }
        }
	}

    public void RecieveDamage()
    {
        Health = Health - 1;    
    }

    public void LanzarRayo(int index)
    {
        Debug.LogWarning("RAYO #" + index);
        switch (index)
        {
            case 1:
                {
                    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, Mathf.Infinity, layerMask);
                    if (hit)
                    {
                        
                        Debug.LogWarning("El rayo le pego a: " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject.tag == "ObstacleCircle")
                        {
                            Debug.Log("Desactive el circulito");
                        }
                    }
                    break;
                }
            case 2:
                {
                    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, Mathf.Infinity, layerMask);
                    if (hit)
                    {
                        Debug.LogWarning("El rayo le pego a: " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject.tag == "ObstaclePolygon")
                        {
                            Debug.Log("Desactive el poligono");
                        }
                    }
                    break;
                }
            case 3:
                {
                    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, Mathf.Infinity, layerMask);
                    if (hit)
                    {
                        Debug.LogWarning("El rayo le pego a: " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject.tag == "ObstacleSquare")
                        {
                            Debug.Log("Desactive el square");
                        }
                    }
                    break;
                }
            case 4:
                {
                    RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, Mathf.Infinity, layerMask);
                    if (hit)
                    {
                        Debug.LogWarning("El rayo le pego a: " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject.tag == "ObstacleTriangle")
                        {
                            Debug.Log("Desactive el triangle");
                        }
                    }
                    break;
                }
        }
    }

}
