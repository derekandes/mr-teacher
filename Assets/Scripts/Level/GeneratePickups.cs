using UnityEngine;
using System.Collections;

public class GeneratePickups : MonoBehaviour {

    public GameObject apple, mushroom, hedgehog;

    public int numberOfApples = 10;
    public int numberOfMushrooms = 7;
    public int numberOfHedgehogs = 3;

    private bool genLastWave = true;

    private int lastAppleCount = 0;
    private int lastMushroomCount = 0;
    private int lastHedgehogCount = 0;

    void Start ()
    {
        GenApples(numberOfApples);
        GenMushrooms(numberOfMushrooms);
        GenHedgehogs(numberOfHedgehogs);
    }

    void Update ()
    {
        
        if (GameManager.instance.apples >= lastAppleCount + 5)
        {
            lastAppleCount = GameManager.instance.apples;
            GenApples(numberOfApples);
        }

        if (GameManager.instance.mushrooms >= lastMushroomCount + 5)
        {
            lastMushroomCount = GameManager.instance.mushrooms;
            GenMushrooms(numberOfMushrooms);
        }
        if (GameManager.instance.hedgehogs >= lastHedgehogCount + 2)
        {
            lastHedgehogCount = GameManager.instance.hedgehogs;
            GenHedgehogs(numberOfHedgehogs);
        }
        if (GameManager.instance.timeLeft <= 10 && genLastWave)
        {
            genLastWave = false;
            GenApples(5);
            GenMushrooms(10);
            GenHedgehogs(5);
        }
    }

    void GenApples(int number)
    {
        for (int i = 0; i < number; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            Instantiate(apple, pos, Quaternion.identity);
        }
    }

    void GenMushrooms(int number)
    {
        for (int i = 0; i < number; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            Instantiate(mushroom, pos, Quaternion.identity);
        }
    }

    void GenHedgehogs(int number)
    {
        for (int i = 0; i < number; i++)
        {
            float xPos = Random.Range(GameManager.instance.leftBound, GameManager.instance.rightBound);
            float yPos = Random.Range(GameManager.instance.downBound, GameManager.instance.upBound);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            Instantiate(hedgehog, pos, Quaternion.identity);
        }
    }
}
