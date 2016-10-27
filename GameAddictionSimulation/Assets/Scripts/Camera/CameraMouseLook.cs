using UnityEngine;
using System.Collections;

//This code is for the camera attached to a parent object
public class CameraMouseLook : MonoBehaviour {

    public float sensitivity;
    public float smoothing;

    private Vector2 mouseLook;
    //prevents mouse movement from feeling jerky
    private Vector2 smoothV;

    GameObject character;

	// Use this for initialization
	void Start () {
        //gets the parent of the camera
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        //adjusted by smoothing and sensitivity
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothV;

        //clamp the mouse so that it cant bend over backwards and look all the way around without turning
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        //mouse vertical invert? mouse look * -1
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
