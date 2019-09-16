using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    //Creates an instance variable to store the character controller
    private CharacterController characterController;
    public Rigidbody head;
    // Start is called before the first frame update
    void Start()
    {
        //Gets a reference to the current component passed into the script
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Creates a new Vector3 to control movement, move direction and move speed
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 
            0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(moveDirection * moveSpeed);
    }
    void FixedUpdate()
    {
        //Calculate the movement direction
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));
        if (moveDirection == Vector3.zero)
        {   
            // TODO
        }
        else
        {
            //Used to make the head move
            head.AddForce(transform.right * 150, ForceMode.Acceleration);
        }
    }
}
