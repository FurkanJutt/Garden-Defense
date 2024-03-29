using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsControler : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    float defaultVolume = 0.8f;
    float defaultDifficulty = 1f;

    MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPerfControler.GetMasterVolume();
        difficultySlider.value = PlayerPerfControler.GetDifficulty();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (musicPlayer)
            musicPlayer.SetVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPerfControler.SetMasterVolume(volumeSlider.value);
        PlayerPerfControler.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelSystem>().LoadStartMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
