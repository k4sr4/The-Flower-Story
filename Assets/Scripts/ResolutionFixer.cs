using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFixer : MonoBehaviour {

    void Awake()
    {
        Screen.SetResolution(620, 980, false);
    }
}
