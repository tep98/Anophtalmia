using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAtack : MonoBehaviour
{
    [SerializeField] private Animator _drone1;
    [SerializeField] private Animator _drone2;
    [SerializeField] private Animator _drone3;  

    [SerializeField] private PlayerController _player;

    private void Start()
    {
        _player.DisableCameras();
        _player.cameras[3].SetActive(true);

        _drone1.SetTrigger("Start");
        _drone2.SetTrigger("Start");
        _drone3.SetTrigger("Start");
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
    }
}
