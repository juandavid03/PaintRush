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
        }
	}

    public void RecieveDamage()
    {
        Health = Health - 1;    
    }

    public void LanzarRayo()
    {

    }

}
