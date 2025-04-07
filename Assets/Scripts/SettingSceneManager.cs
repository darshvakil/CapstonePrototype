using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class SettingSceneManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public Button resumeButton;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }



        if (PlayerPrefs.GetInt("FromGame", 0) == 1)
        {
            resumeButton.gameObject.SetActive(true);
        }
        else
        {
            resumeButton.gameObject.SetActive(false);
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("HomeScene"); // Replace with your actual home scene name
    }

    public void ResumeGame()
    {
        PlayerPrefs.SetInt("FromGame", 0);
        SceneManager.LoadScene("SampleScene"); // Replace with your actual game scene name
    }

}

