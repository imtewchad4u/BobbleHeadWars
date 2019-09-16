using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Destroys the bullet when it goes off screen
    private void OnBecameInvisible()
    { Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
