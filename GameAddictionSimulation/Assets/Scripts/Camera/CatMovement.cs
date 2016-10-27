using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

    public float speed; // speed that the cat travels at
    public float jumpHeight; // the height the cat can jump on key input

    private Rigidbody rigidbody; // rigidbody reference for the cat
    private string forwardMovementAxis; // axis input for moving the way camera is facing
    private string sidewaysMovementAxis; // axis input for strafing
    private float forwardMovementValue; // value to control how far one input moves forward
    private float sidewaysMovementValue; // value to control how far one input moves sideways

	// Use this for initialization
	void Start () {
        //get the rigidbody to apply physics
        rigidbody = GetComponent<Rigidbody>();
        forwardMovementAxis = "Vertical";
        sidewaysMovementAxis = "Horizontal";
	}
	
	// Update is called once per frame
	void Update () {
        forwardMovementValue = Input.GetAxis(forwardMovementAxis);
        sidewaysMovementValue = Input.GetAxis(sidewaysMovementAxis);
	}

    // Update per physics update
    void FixedUpdate()
    {
        MoveForward();
        MoveSideways();
    }

    //forward movement input
    private void MoveForward()
    {
        //vector to get the direction of forward movement
        Vector3 movement = transform.forward * forwardMovementValue * speed * Time.deltaTime;
        //apply to the rigidbody
        rigidbody.MovePosition(rigidbody.position + movement);
    }

    //sideways movement input
    private void MoveSideways()
    {
        //vector to get the direction of forward movement
        Vector3 movement = transform.right * sidewaysMovementValue * speed * Time.deltaTime;
        //apply to the rigidbody
        rigidbody.MovePosition(rigidbody.position + movement);
    }
}
