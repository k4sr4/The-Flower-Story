using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    public bool activate = false;
    float lastFall = 0;

    private void Update()
    {
        if (activate)
        {
            if (Time.time - lastFall >= 1)
            {
                // Modify position
                transform.position += new Vector3(0, -1, 0);

                lastFall = Time.time;

                if (transform.position.y < -1f)
                {
                    activate = false;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
