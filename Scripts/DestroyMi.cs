using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMi : MonoBehaviour
{
    public int lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifetime); // texti yoket sürede
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
