﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {
    public int points = 1;
    bool canHit = true;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Arcade")
        {
            this.enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine("Count");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Block" && canHit && SceneManager.GetActiveScene().name == "Arcade")
        {
            GetComponentInParent<Transform>().position = new Vector2(Random.Range(0f, 12f), Random.Range(0f, 17f));
        }
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(.25f);
        canHit = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
