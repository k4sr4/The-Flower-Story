using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public GameObject[] groups;

    GameObject current;

	// Use this for initialization
	void Start () {
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
        int choice = Random.Range(0, groups.Length);
        current = Instantiate(groups[choice], transform);        
    }

    public void ActivateBomb()
    {
        Destroy(current);
        Invoke("SpawnNext", 1.5f);
    }
}
