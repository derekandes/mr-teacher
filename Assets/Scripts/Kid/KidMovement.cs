using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class KidMovement : MonoBehaviour
{
    public bool moving = false;
    private bool facingRight = false;

    private Vector3 distToMove;
    private Vector3 whereToMove;
    private float moveDelay;

    private Vector3 lastPos;
    public bool anim = false;

    void Start ()
    {
        DecideMovementDelay();
        lastPos = transform.position;
    }

	void Update ()
	{
        if (!moving)
        {
            Move();
        }

        if (transform.position != lastPos)
        {
            anim = true;
        }
        else anim = false;

        lastPos = transform.position;
	}
    
    void Move()
    {
        //SET DISTANCE TO MOVE
        float x = Random.Range(2f, 5f);
        float y = Random.Range(2f, 5f);

        //SET MOVEMENT TO EITHER POSITIVE OR NEGATIVE VALUE (COIN FLIP)
        int moveCheck = Random.Range(1, 3);
        if (moveCheck == 1) x = -x;

        moveCheck = Random.Range(1, 3);
        if (moveCheck == 1) y = -y;
        
        distToMove = new Vector3(x, y, 0f);

        //FLIP X SCALE IF NEEDED
        if (distToMove.x < 0)
        {
            if (!facingRight) Flip();
        }
        else
        {
            if (facingRight) Flip();
        }

        //SET NEW POSITION AND CLAMP TO GLOBAL BOUNDS
        whereToMove = transform.position + distToMove;
        if (whereToMove.y >= GameManager.instance.upBound) whereToMove.y = GameManager.instance.upBound;
        if (whereToMove.y <= GameManager.instance.downBound) whereToMove.y = GameManager.instance.downBound;
        if (whereToMove.x >= GameManager.instance.rightBound) whereToMove.x = GameManager.instance.rightBound;
        if (whereToMove.x <= GameManager.instance.leftBound) whereToMove.x = GameManager.instance.leftBound;

        moving = true;
        transform.ZKpositionTo(whereToMove, 1f)
            .setDelay(moveDelay)
            .setEaseType(EaseType.Linear)
            .setCompletionHandler(t => DecideMovementDelay())
            .start();
    }

    public void DecideMovementDelay()
    {
        //NOT MOVING
        moving = false;
        //SET DELAY
        moveDelay = Random.Range(.1f, 2f);
    }

    //FLIP X SCALE
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
