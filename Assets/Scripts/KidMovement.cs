using UnityEngine;
using System.Collections;

public class KidMovement : MonoBehaviour
{
    private bool moving = false;
    private bool facingRight = false;

    private Vector3 distToMove;
    private Vector3 whereToMove;
    private float moveDelay;

	void Update ()
	{
        if (!moving)
        {
            Move();
        }
	}
    
    void Move()
    {
        //SET DISTANCE TO MOVE
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(-3f, 3f);
        distToMove = new Vector3(x, y, 0f);

        //FLIP X SCALE IF NEEDED
        if (distToMove.x >= 0)
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
        PositionTweenProperty positionProperty = new PositionTweenProperty(whereToMove);
        GoTweenConfig config = new GoTweenConfig();
        config.addTweenProperty(positionProperty);
        config.onComplete(t => StartCoroutine(Moved()));
        GoTween tween = new GoTween(transform, 1f, config);
        Go.addTween(tween);
        
    }

    IEnumerator Moved()
    {
        moveDelay = Random.Range(.25f, 1.5f);
        yield return new WaitForSeconds(moveDelay);
        moving = false;
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