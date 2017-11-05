using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeController : MonoBehaviour {

    public GameObject goal;
    public GameObject superGoal;
    public Text pointsText;
    public int numGoalsToClear = 10;
    public GameObject[] items;
    int points = 0;
    int clearPoints = 0;
    float itemSpawnTime = 0f;
    GameObject spawnedItem;

	// Use this for initialization
	void Start () {
        itemSpawnTime = Random.Range(20f, 30f);
        Invoke("SpawnItem", itemSpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (clearPoints >= numGoalsToClear && Input.GetKey(KeyCode.Return))
        {
            clearPoints = 0;

            Group[] blocks = FindObjectsOfType<Group>();

            foreach (Group g in blocks)
            {
                Destroy(g.gameObject);
            }

            FindObjectOfType<Spawner>().SpawnNext();
        }
    }

    private void SpawnItem()
    {
        int choice = Random.Range(1, 3);

        if(spawnedItem != null)
        {
            Destroy(spawnedItem);
        }

        int index = Random.Range(0, items.Length);
        GameObject toSpawn = items[index];
        spawnedItem = Instantiate(toSpawn, transform);

        if (choice == 1)
        {
            do
            {
                Vector2 newPos = new Vector2(UnityEngine.Random.Range(0f, 12f), UnityEngine.Random.Range(1f, 17f));
                spawnedItem.transform.position = newPos;
            }
            while (Physics2D.OverlapCircle(spawnedItem.transform.position, .5f).tag == "Block");
        }

        if(choice == 2)
        {
            float xPos = Random.Range(0f, 12f);
            spawnedItem.transform.position = new Vector2(xPos, 22f);
            spawnedItem.GetComponent<ItemScript>().activate = true;
        }

        itemSpawnTime = Random.Range(20f, 30f);
        Invoke("SpawnItem", itemSpawnTime);
    }

    public void InstantiateFlower()
    {
        GameObject toInstantiate;
        int choice = Random.Range(1, 6);
        if(choice == 5)
        {
            toInstantiate = superGoal;
        }
        else
        {
            toInstantiate = goal;
        }

        GameObject newGoal = Instantiate(toInstantiate, transform);
        Vector2 newPos = new Vector2(Random.Range(0f, 12f), Random.Range(0f, 16f));
        newGoal.transform.localPosition = newPos;
    }

    public void AddPoints(int added)
    {
        points += added;
        clearPoints += added;
        pointsText.text = "Points: " + points;
    }
}
