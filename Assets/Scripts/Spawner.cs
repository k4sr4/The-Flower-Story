using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public GameObject[] groups;

	// Use this for initialization
	void Start () {
        StartCoroutine("WaitAndSpawn");               
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void spawnNext()
    {                
        int choice = Random.Range(0, groups.Length);
        Instantiate(groups[choice], transform);        
    }

    IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(1.5f);
        spawnNext();
    }
}
