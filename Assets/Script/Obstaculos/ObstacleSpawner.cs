using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] obstacles;

    public float timer;

    public float minTime;

    public float maxTime;

    // Use this for initialization
    void Start ()
    {
        timer = Random.Range(minTime, maxTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            InvocarObstaculo();
        }
	}

    private void InvocarObstaculo()
    {
        var index = Random.Range(0, 4);
        Instantiate(obstacles[index], this.transform.position, Quaternion.identity);
        timer = Random.Range(minTime, maxTime);
    }
}
