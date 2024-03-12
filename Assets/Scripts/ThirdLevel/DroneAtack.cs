using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAtack : MonoBehaviour
{
    [SerializeField] private Animator _drone1;
    [SerializeField] private Animator _drone2;
    [SerializeField] private Animator _drone3;

    [SerializeField] private GameObject _drone1Object;
    [SerializeField] private GameObject _drone2Object;
    [SerializeField] private GameObject _drone3Object;

    [SerializeField] private GameObject _Door;  

    [SerializeField] private CameraSwitcher _switcher;
    [SerializeField] private AudioSource _EpicMusic;
    [SerializeField] private AudioSource _NormalMusic;

    [SerializeField] private GameObject _text1;
    [SerializeField] private GameObject _text2;
    [SerializeField] private GameObject _text3;
    private void Start()
    {
        _switcher.DisableCameras();
        _switcher.cameras[3].SetActive(true);
        _switcher.enabled = false;

        _drone1Object.SetActive(true);
        _drone2Object.SetActive(true);
        _drone3Object.SetActive(true);

        _drone1.SetTrigger("Start");
        _drone2.SetTrigger("Start");
        _drone3.SetTrigger("Start");

        _NormalMusic.Stop();
        _EpicMusic.Play();

        _text1.SetActive(false);
        _text2.SetActive(true);
    }
    public void DroneToExit()
    {
        Invoke("Drone", 7f);
    }
    private void Drone()
    {
        _drone1.SetTrigger("End");
        _drone2.SetTrigger("End");
        _drone3.SetTrigger("End");

        _switcher.enabled = true;

        _Door.GetComponent<LevelDoor>().enabled = true;

        _EpicMusic.Stop();
        _NormalMusic.Play();

        _text2.SetActive(false);
        _text3.SetActive(true);
    }
}
