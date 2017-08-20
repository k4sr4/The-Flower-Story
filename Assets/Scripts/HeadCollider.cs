using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block" && other.GetComponentInParent<Group>().enabled)
        {
            // It's not valid. revert.
            //other.GetComponentInParent<Transform>().position += new Vector3(0, 1, 0);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
