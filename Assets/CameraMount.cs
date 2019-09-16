using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMount : MonoBehaviour
{
    //Makes the camera follow the target
    public GameObject followTarget;
    //The speed the camera follows at
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if there is a target to follow
        if (followTarget != null)
        {
            transform.position = Vector3.Lerp(transform.position, 
                followTarget.transform.position, Time.deltaTime * moveSpeed);
        }
    }
}
