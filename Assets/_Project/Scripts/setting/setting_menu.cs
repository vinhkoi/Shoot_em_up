using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class setting_menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown dropdown_Resolution;
    Resolution[] resolutions;
    void Start()
    {
       resolutions = Screen.resolutions;
       dropdown_Resolution.ClearOptions();
       List<string> options = new List<string>();
       int currentResolutionIndex = 0;
       for(int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) { 
                currentResolutionIndex = i;
            }
        }
       dropdown_Resolution.AddOptions(options);
       dropdown_Resolution.value = currentResolutionIndex;
       dropdown_Resolution.RefreshShownValue();    
    }
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
    //public void setVolume(float volume)
    //{
    //    audioMixer.SetFloat("Volume",volume);
    //}
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }


}
