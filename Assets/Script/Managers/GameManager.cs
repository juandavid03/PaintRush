using UnityEngine;

public class GameManager : MonoBehaviour
{

    private MenuManager manager;

	// Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Personaje.Instance.Health == 0)
        {
            Time.timeScale = 0;
            Perder();
        }
	}

    private void Perder()
    {
        Personaje.Instance.isPaused = true;
        var currentAvailablePoints = PlayerPrefs.GetFloat("AvailablePoints");
        PlayerPrefs.SetFloat("SesionPoints", Personaje.Instance.Points);
        PlayerPrefs.SetFloat("AvailablePoints", currentAvailablePoints+ Personaje.Instance.Points);
        manager.LoadScene("EndgameInfoScreen");
    }
}
