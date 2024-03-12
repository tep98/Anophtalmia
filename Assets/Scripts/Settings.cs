using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public AudioSource audioMixer;
    public AudioSource audioSourceForClick;
    public AudioSource clickAudio;
    public UnityEngine.UI.Slider volumeSlider;
    public UnityEngine.UI.Slider sensivitySlider;
    float currentVolume;
    int startSettings = 0;
    public GameObject settingsPanel;
    public GameObject _camera;
    public TextMeshProUGUI mouseSensivityText;
    void Awake()
    {
        _camera = FindObjectOfType<Camera>().gameObject;
        GetLocalData();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
   /* private void OnApplicationFocus(bool focus)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
   */
    public void ClickSound()
    {
        if (clickAudio != null)
            clickAudio.Play();
    }
    void GetLocalData()
    {
        startSettings = PlayerPrefs.GetInt("startMusicVolume");
        Debug.Log("œ–Œ¬≈– ¿ œ≈–¬Œ√Œ «¿œ”— ¿: " + startSettings);
        if (startSettings == 1)
        {
            if ((_camera != null)&&(_camera.GetComponent<CameraController>() != null))
            {
                _camera.GetComponent<CameraController>().mouseSensitivity = PlayerPrefs.GetFloat("SensivityPreference") * 100;
            }
            //gameObject.GetComponent<CameraController>().sensitivity = PlayerPrefs.GetFloat("SensivityPreference")* 100;
            mouseSensivityText.text = PlayerPrefs.GetFloat("SensivityPreference").ToString("F2");
            Debug.Log("— Œ ¿ «¬” ¿ »«Õ¿◊¿À‹ÕŒ: " + currentVolume);
            currentVolume = PlayerPrefs.GetFloat("VolumePreference");
            Debug.Log("— Œ ¿ «¬” ¿: " + currentVolume);
            sensivitySlider.value = PlayerPrefs.GetFloat("SensivityPreference");
            volumeSlider.value = currentVolume;
            audioMixer.volume = currentVolume;
        }
        else
        {
            if ((_camera != null) && (_camera.GetComponent<CameraController>() != null))
            {
                _camera.GetComponent<CameraController>().mouseSensitivity = 100;
            }
            PlayerPrefs.SetFloat("SensivityPreference", 1);
            Debug.Log("ﬂ œŒ—“¿¬»À Ã¿ —»Ã”Ã «¬” ¿: " + currentVolume);
            currentVolume = 0.5f;
            //  SetSensivity(1f);
            audioMixer.volume = currentVolume;
            sensivitySlider.value = 1;
            volumeSlider.value = 1f;
            PlayerPrefs.SetFloat("VolumePreference", currentVolume);
            startSettings = 1;
            PlayerPrefs.SetInt("startMusicVolume", startSettings);
            PlayerPrefs.Save();
        }
    }
        public void SetSensivity(float sensivity)
    {
        //  StopAllCoroutines();
        if ((_camera != null) && (_camera.GetComponent<CameraController>() != null))
        {
            _camera.GetComponent<CameraController>().mouseSensitivity = sensivity * 100;
        }
            PlayerPrefs.SetFloat("SensivityPreference", sensivity);
        PlayerPrefs.Save();
        mouseSensivityText.text = sensivity.ToString("F2");
    }
    public void SetVolume(float volume)
    {
        if (volume <= 0.5f)
        {
            audioMixer.volume = volume;
            currentVolume = volume;
        }
        else
        {
            audioMixer.volume = 0.5f;
            currentVolume = 0.5f;
        }
    }
    public void SettingsButton()
    {
        ClickSound();
        settingsPanel.SetActive(true);
    }
    public void CloseSettingsButton()
    {
        ClickSound();
        settingsPanel.SetActive(false);
    }
    public void StartButton()
    {
        ClickSound();
        SceneManager.LoadScene("Prologue");
    }
    public void ExitButton()
    {
        ClickSound();
        Application.Quit();
    }
}