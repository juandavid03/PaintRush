using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] obstacles;

    public float timer;

    public float minTime;

    public float maxTime;

    private int maxObstacles = 4;

    // Use this for initialization
    void Start ()
    {
        minTime = 4;
        maxTime = 5;
        timer = Random.Range(minTime, maxTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(Time.time);
        if (Time.time < 10)
        {
            minTime = 4;
            maxTime = 5;
        }
        if (Time.time > 10 && Time.time < 20)
        {
            minTime = 3;
            maxTime = 4;
        }
        if (Time.time > 20 && Time.time < 40)
        {
            minTime = 2;
            maxTime = 3;
        }
        if (Time.time > 40 && Time.time < 60)
        {
            minTime = 1;
            maxTime = 2;
        }
        if (Time.time > 60)
        {
            minTime = 1;
            maxTime = 1;
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            InvocarObstaculo();
        }
	}

    private void InvocarObstaculo()
    {
        var index = Random.Range(0, maxObstacles);
        Instantiate(obstacles[index], this.transform.position, Quaternion.identity);
        timer = Random.Range(minTime, maxTime);
    }
}
