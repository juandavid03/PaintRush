using UnityEngine;

public class DataSender : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Shader.SetGlobalVector("paintPosition", this.transform.position);
	}
}
