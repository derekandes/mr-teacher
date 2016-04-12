using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //FOR MOVEMENT
    public float speed = 7f;

    //FOR FLIPPING X SCALE
    private bool facingRight = true;

	void Update ()
    {
        //GET INPUT AXIS
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;

        //HANDLE FLIPPING X SCALE
        if (h > 0)
        {
            if (facingRight == false)
            {
                Flip();
            }
        }
        else if (h < 0)
        {
            if (facingRight == true)
            {
                Flip();
            }
        }

        //SCALE INPUT BY DELTA TIME
        h *= Time.deltaTime;
        v *= Time.deltaTime;

        //DO MOVEMENT & CLAMP TO GAME BOUNDS
        transform.Translate(h, v, 0);
        float yClamp = Mathf.Clamp(transform.position.y, GameManager.instance.downBound, GameManager.instance.upBound);
        float xClamp = Mathf.Clamp(transform.position.x, GameManager.instance.leftBound, GameManager.instance.rightBound);
        transform.position = new Vector3(xClamp, yClamp, transform.position.z);
	}

    //FLIP X SCALE
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
