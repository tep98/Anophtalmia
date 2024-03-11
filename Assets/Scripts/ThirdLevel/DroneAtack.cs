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

        _drone1.SetTrigger("Started");
        _drone2.SetTrigger("Started");
        _drone3.SetTrigger("Started");
    }
}
