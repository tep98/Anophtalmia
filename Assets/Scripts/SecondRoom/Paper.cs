using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _paperCanvas;
    public static int count = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _paperCanvas.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _paperCanvas.SetActive(false);
                count++;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
    }
}
