using UnityEngine;
using System.Collections;

public class GeneratePickups : MonoBehaviour {

    public GameObject apple, mushroom, hedgehog;

    public int numberOfApples = 2;
    public int numberOfMushrooms = 2;
    public int numberOfHedgehogs = 2;

    public bool genLastWave = true;

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
        
        if (GameManager.instance.apples >= lastAppleCount + 4)
        {
            lastAppleCount = GameManager.instance.apples;
            GenApples(numberOfApples - 1);
        }

        if (GameManager.instance.mushrooms >= lastMushroomCount + 4)
        {
            lastMushroomCount = GameManager.instance.mushrooms;
            GenMushrooms(numberOfMushrooms - 1);
        }
        if (GameManager.instance.hedgehogs >= lastHedgehogCount + 4)
        {
            lastHedgehogCount = GameManager.instance.hedgehogs;
            GenHedgehogs(numberOfHedgehogs - 1);
        }
        if (GameManager.instance.timeLeft <= 10 && genLastWave)
        {
            genLastWave = false;
            GenApples(numberOfApples);
            GenMushrooms(numberOfMushrooms);
            GenHedgehogs(numberOfHedgehogs);
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
