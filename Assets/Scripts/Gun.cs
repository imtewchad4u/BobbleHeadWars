using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Set the bullet Prefab
    public GameObject bulletPrefab;
    //Set the position of the gun barrel
    public Transform launchPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void fireBullet()
    {
        //creates a game object instance
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;   
        //bullet position is set to the launcher position
        bullet.transform.position = launchPosition.position;  
        //adds velocity and directions to the bullet
        bullet.GetComponent<Rigidbody>().velocity =      
            transform.parent.forward * 100;
    }

        // Update is called once per frame
        void Update()
    {
        //Checks for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            //Checks if the left mouse is being held down
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }
        //Checks if the left mouse button was released
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
    }
}
