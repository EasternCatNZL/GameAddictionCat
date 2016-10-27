using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

    public bool fadingIn = false;
    public bool fadingOut = false;

    private float alphaLevel; // alpha of shape

	// Use this for initialization
	void Start () {
        alphaLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //fades the object alpha to black
    private void FadeIn()
    {
        //get the render on object and change the alpha
        while (fadingIn)
        {
            //change the alpha relative to time
            alphaLevel += 0.05f * Time.deltaTime;
            //get the spriterender on plane
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            //keep values between 0 and 1
            alphaLevel = Mathf.Clamp(alphaLevel, 0.0f, 1.0f);
            if (alphaLevel == 1)
            {
                fadingIn = false;
            }
        }
    }

    //fades the object alpha to transparent
    private void FadeOut()
    {
        //get the render on object and change the alpha
        while (fadingOut)
        {
            //change the alpha relative to time
            alphaLevel -= 0.05f * Time.deltaTime;
            //get the spriterender on plane
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            //keep values between 0 and 1
            alphaLevel = Mathf.Clamp(alphaLevel, 0.0f, 1.0f);
            if (alphaLevel == 1)
            {
                fadingOut = false;
            }
        }
    }
}
