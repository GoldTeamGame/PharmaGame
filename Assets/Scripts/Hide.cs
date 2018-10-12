using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

    public GameObject obj;

    public void Enable()
    {
        obj.SetActive(true);
    }
    public void disable()
    {
        obj.SetActive(false);
    }
}
