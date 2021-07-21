using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] Slider difSlider = null;
    [SerializeField] float defaultVolume = 1f;
    [SerializeField] float defaultDif = 0;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difSlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music Player found, make sure to start from splash screen");
        }

    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difSlider.value);
        FindObjectOfType<SceneLoader>().LoadMainScene();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difSlider.value = defaultDif;

    }
}
