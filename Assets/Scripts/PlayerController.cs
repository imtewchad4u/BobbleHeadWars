using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    //Creates an instance variable to store the character controller
    private CharacterController characterController;
    public Rigidbody head;
    public LayerMask layerMask;
    private Vector3 currentLookTarget = Vector3.zero;
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
        //Creates an empty raycast when you get a hit
        RaycastHit hit;
        //Casts the ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
        if (Physics.Raycast(ray, out hit, 1000, layerMask, 
            QueryTriggerInteraction.Ignore))
        {
            if (hit.point != currentLookTarget)
            {
                currentLookTarget = hit.point;
            }
            Vector3 targetPosition = new Vector3(hit.point.x,    
                transform.position.y, hit.point.z);
            Quaternion rotation = Quaternion.LookRotation(targetPosition -    
                transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation,    
                rotation, Time.deltaTime * 10.0f);
        }

    }
}
