using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource source;

    private void Start()
    {
       //source = GameObject.Find("EffectSource").GetComponent<AudioSource>();
    }

    public void LoadScene(string nextScene)
    {
        source.PlayOneShot(source.clip);
        SceneManager.LoadScene(nextScene);
    }

    public void Salir()
    {
        source.PlayOneShot(source.clip);
        Application.Quit();
    }

}
