using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class SneakyMushroom : MonoBehaviour
{
    private Vector3 theScale;

	void Start ()
    {
        theScale = transform.localScale;
        transform.localScale = new Vector3(theScale.x, 0, theScale.z);
        PopUp();
    }
	
	void Update ()
    {
	
	}

    void PopUp ()
    {
        transform.ZKlocalScaleTo(theScale, 1f)
            .setEaseType(EaseType.ElasticOut)
            .setCompletionHandler(t => StartCoroutine(WaitAndDisappear()))
            .start();
    }

    IEnumerator WaitAndDisappear()
    {
        yield return new WaitForSeconds(Random.Range(1,4));
        Disappear();
    }

    void Disappear ()
    {
        transform.ZKlocalScaleTo(new Vector3(theScale.x, 0, theScale.z), 1f)
            .setEaseType(EaseType.ElasticIn)
            .setCompletionHandler(t => RespawnAndDestroy())
            .start();
    }

    void RespawnAndDestroy ()
    {   //will need to clamp to bounds
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, 0);

        int check = Random.Range(1, 100);
        if (check % 2 == 0)
        {
            newPosition.x += 2;
        }
        else newPosition.x -= 2;

        check = Random.Range(1, 100);
        if (check % 2 == 0)
        {
            newPosition.y += 2;
        }
        else newPosition.y -= 2;

        GameObject instance = Instantiate(Resources.Load("Prefabs/Mushroom")) as GameObject;
        instance.transform.position = newPosition;
        Destroy(gameObject);
    }
}
