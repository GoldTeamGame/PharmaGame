using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SwitchScene : MonoBehaviour {

    
    public void ChangeScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void BackToStore()
    {
        Application.LoadLevel("Storefront");
    }
}
