using UnityEngine;
using System.Collections;

public class GenerateKids : MonoBehaviour {

    public GameObject kid1, kid2, kid3, kid4;

    public int numberOfKids1 = 2;
    public int numberOfKids2 = 2;
    public int numberOfKids3 = 2;
    public int numberOfKids4 = 2;

    void Start ()
    {
        GenKids();
	}

    void GenKids ()
    {
        for (int i = 0; i < numberOfKids1; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            Instantiate(kid1, pos, Quaternion.identity);
        }

        for (int i = 0; i < numberOfKids2; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            Instantiate(kid2, pos, Quaternion.identity);
        }

        for (int i = 0; i < numberOfKids3; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            Instantiate(kid3, pos, Quaternion.identity);
        }

        for (int i = 0; i < numberOfKids4; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            Instantiate(kid4, pos, Quaternion.identity);
        }
    }
}
