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

    [SerializeField] private PlayerController _player;
    [SerializeField] private AudioSource _EpicMusic;
    [SerializeField] private AudioSource _NormalMusic;

    private void Start()
    {
        _player.DisableCameras();
        _player.cameras[3].SetActive(true);

        _drone1Object.SetActive(true);
        _drone2Object.SetActive(true);
        _drone3Object.SetActive(true);

        _drone1.SetTrigger("Start");
        _drone2.SetTrigger("Start");
        _drone3.SetTrigger("Start");

        _NormalMusic.Stop();
        _EpicMusic.Play();
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

        _Door.GetComponent<LevelDoor>().enabled = true;

        _EpicMusic.Stop();
        _NormalMusic.Play();
    }
}
