using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsController.SetMasterVolume(0.9f);
        Debug.Log("Master Volume" + PlayerPrefsController.GetMasterVolume());

    }

    // Update is called once per frame
    void Update()
    {
    }
}
