using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public GameObject[] groups;
    public GameObject nextBlock;
    public Sprite[] nextBlockSprites;
    private int choice;

    GameObject current;

	// Use this for initialization
	void Start () {
        choice = Random.Range(0, groups.Length);

        Invoke("SpawnNext", 1.5f);            
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void SpawnNext()
    {                
        current = Instantiate(groups[choice], transform);
        choice = Random.Range(0, groups.Length);
        nextBlock.GetComponent<SpriteRenderer>().sprite = nextBlockSprites[choice];
    }

    public void ActivateBomb()
    {
        Destroy(current);
        Invoke("SpawnNext", 1.5f);
    }
}
