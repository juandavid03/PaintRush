using UnityEngine.UI;
using UnityEngine;

public class StoreManager : MonoBehaviour
{

    public Text textPuntosDisponibles;
    public Text testText;
    private float testPoints = 5;
	// Use this for initialization
	void Start ()
    {
        testText.text = "No has comprado nada";
	}
	
	// Update is called once per frame
	void Update ()
    {
       var points = PlayerPrefs.GetFloat("AvailablePoints");
        textPuntosDisponibles.text = "Puntos Disponibles: " + points.ToString();
	}

    public void testSetPref()
    {
        var currentAvailablePoints = PlayerPrefs.GetFloat("AvailablePoints");
        PlayerPrefs.SetFloat("AvailablePoints", currentAvailablePoints+testPoints);
    }

    public void ResetPref()
    {
        PlayerPrefs.SetFloat("AvailablePoints", 0);
    }

    public void Comprar(Upgrade upgrade)
    {
        var currentAvailablePoints = PlayerPrefs.GetFloat("AvailablePoints");
        if (currentAvailablePoints > upgrade.Cost)
        {
            testText.text = upgrade.UpgradeName;
            PlayerPrefs.SetFloat("AvailablePoints", currentAvailablePoints - upgrade.Cost);
        }
        else
        {
            testText.text = "No tienes puntos para esto";
        }
    }
}
