using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioClip sound = null;
    Button button
    {
        get { return GetComponent<Button>(); }
    }
    AudioSource source { get { return GetComponent<AudioSource>(); } }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => StartSound());


    }

    void StartSound()
    {
        source.PlayOneShot(sound);
    }

}
