using UnityEngine;
using UnityEngine.UI;

public class FinalInfoPrinter : MonoBehaviour
{
    private Text finalPointsText;
     private Text availablePointsText;
    // Use this for initialization
    void Start ()
    {
        finalPointsText = GameObject.Find("textFinalPoints").GetComponent<Text>();
        availablePointsText = GameObject.Find("textAvailablePoints").GetComponent<Text>();
        var availablePoints = PlayerPrefs.GetFloat("AvailablePoints");
        var points = PlayerPrefs.GetFloat("SesionPoints");
        finalPointsText.text = "Puntos Ganados: " + points.ToString();
        availablePointsText.text = "Puntos Disponibles: " + availablePoints.ToString();
        
    }
	
}
