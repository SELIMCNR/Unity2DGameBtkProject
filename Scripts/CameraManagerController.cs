using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target; // hedef obje deðiþkeni
    public float cameraSpeed; //kamera hýzý
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hedef objeyi kamera ile takip et
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), cameraSpeed);
    }
}
