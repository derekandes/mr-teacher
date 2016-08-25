using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //FOR MOVEMENT
    public float speed = 7f;

	void Update ()
    {
        if (GameManager.instance.levelEnded) return;

        //GET INPUT AXIS
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;
        

        //CHECK DIRECTION AND FLIP X SCALE IF NEEDED (THANKS HUBOL)
        if (Mathf.Sign(h) != Mathf.Sign(transform.localScale.x) && h != 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        //SCALE INPUT BY DELTA TIME
        h *= Time.deltaTime;
        v *= Time.deltaTime;

        //DO MOVEMENT & CLAMP TO GAME BOUNDS
        transform.Translate(h * transform.localScale.x, v, 0);
        float yClamp = Mathf.Clamp(transform.position.y, GameManager.instance.downBound, GameManager.instance.upBound);
        float xClamp = Mathf.Clamp(transform.position.x, GameManager.instance.leftBound, GameManager.instance.rightBound);
        transform.position = new Vector3(xClamp, yClamp, transform.position.z);
	}
}
