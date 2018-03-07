using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject cameraObj;
    public Vector3 specificVector;
    public float smoothSpeed;
 
    public void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
    }

    public void Update()
    {
        specificVector = new Vector3(transform.position.x, transform.position.y + (Screen.height * 0.01f), cameraObj.transform.position.z);
        cameraObj.transform.position = Vector3.Lerp(cameraObj.transform.position, specificVector, smoothSpeed * Time.deltaTime);
    }
}
