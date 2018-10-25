using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButton : MonoBehaviour
{
    Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Hide());
    }

    void Hide()
    {
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
