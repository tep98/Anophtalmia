using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _errorCanvas;
    [SerializeField] private GameObject _droneManager;

    private bool _enabled = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canvas.activeSelf)
        {
            _enabled = true;
            _canvas.SetActive(false);
            _errorCanvas.SetActive(true);
            Invoke("DisableCanvas", 2f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player") && PasswordsPaper.count == 3)
        if (other.CompareTag("Player"))
        {
            if (!_enabled) _canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
    }

    private void DisableCanvas()
    {
        _errorCanvas.SetActive(false);
        _droneManager.SetActive(true);
    }
}