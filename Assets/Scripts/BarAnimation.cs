using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarAnimation : MonoBehaviour {
    bool yellow = true;

	// Update is called once per frame
	void Start () {
        ChangeColor();
	}

    void ChangeColor()
    {
        if (yellow)
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            yellow = false;
            Invoke("ChangeColor", .25f);
        }
        else
        {
            GetComponent<Image>().color = new Color32(199, 255, 0, 255);
            yellow = true;
            Invoke("ChangeColor", .25f);
        }
    }
}
