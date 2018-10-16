using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchScene : MonoBehaviour {

    
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
