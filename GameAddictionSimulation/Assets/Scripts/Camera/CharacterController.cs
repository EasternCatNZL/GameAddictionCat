using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour{

	public float speed; //speed at which character travels
    public float jumpForce; //force added to character during jumps
    public float rayVariation; //float to add more length to raycast, to give more wiggle room in calculations
    public float height; //holds the height of the object
    public float gravity; //gravity affecting character

    //private Transform transform; //transform of the object
    private Rigidbody rigidbody; //holds the rigidbody component
    private bool grounded; // holds bool flag to check if object is grounded
    

	//Use this for intialization
	void Start()
	{
		//Turn off cursor, not seen on screen, keeps cursor in game window
		Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity * -1.0f, 0);
	}

	//Update is called once per frame
	void Update(){
        Move();
        grounded = IsGrounded();

        //ray for dubug purposes
        //Debug.DrawRay(transform.position, Vector3.down, Color.red);
	}

    //Movement script
    private void Move()
    {
        //takes vertical input
        float translation = Input.GetAxis("Vertical") * speed;
        //takes horizontal input
        float straffe = Input.GetAxis("Horizontal") * speed;
        //keeps in time with update
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        //Change cursor back to normal
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        //Add force for jumps
        if (Input.GetKeyDown("space"))
        {
            if (IsGrounded())
            {
                rigidbody.velocity = new Vector3(0, jumpForce, 0);
            }
        }
            
    }

    private bool IsGrounded()
    {
        bool isOnGround = false;

        if (Physics.Raycast(transform.position, Vector3.down, height / 2 + rayVariation))
        {
            isOnGround = true;
        }
        return isOnGround;
    }
}