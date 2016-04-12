using UnityEngine;
using System.Collections;

public class GenerateScenery : MonoBehaviour
{
    public GameObject flower;

    public int numberOfFlowers = 20;

	void Start ()
    {
        GenScenery();
	}
	
	void GenScenery ()
    {
        for (int i = 0; i < numberOfFlowers; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            GameObject instance = Instantiate(flower, pos, Quaternion.identity) as GameObject;
            instance.transform.parent = gameObject.transform;
        }
    }
}
