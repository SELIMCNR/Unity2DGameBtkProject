using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public float bulletDamage, lifetime;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifetime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
