using UnityEngine;
using System.Collections;

public class GeneratePickups : MonoBehaviour {

    public GameObject apple, mushroom, hedgehog;

    public int numberOfApples = 3;
    public int numberOfMushrooms = 10;
    public int numberOfHedgehogs = 1;

	void Start ()
    {
        InvokeRepeating("GenApples", 0f, 10f);
        InvokeRepeating("GenMushrooms", 0f, 20);
        InvokeRepeating("GenHedgehogs", 0f, 20f);
    }

    void GenApples()
    {
        for (int i = 0; i < numberOfApples; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            GameObject instance = Instantiate(apple, pos, Quaternion.identity) as GameObject;
            //instance.transform.parent = gameObject.transform;
        }
    }

    void GenMushrooms()
    {
        for (int i = 0; i < numberOfMushrooms; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            GameObject instance = Instantiate(mushroom, pos, Quaternion.identity) as GameObject;
            //instance.transform.parent = gameObject.transform;
        }
    }

    void GenHedgehogs()
    {
        for (int i = 0; i < numberOfHedgehogs; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            GameObject instance = Instantiate(hedgehog, pos, Quaternion.identity) as GameObject;
            //instance.transform.parent = gameObject.transform;
        }
    }
}
