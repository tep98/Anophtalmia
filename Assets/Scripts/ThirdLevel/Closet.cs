using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Closet : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _playerHidePosition = new Vector3(9.730f, 0.689f, 0.959f);
    private Quaternion _playerHideRotation = new Quaternion(0, -70f, 0, 1);
    private Vector3 _playerPosition;
    private GameObject _player;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _cam;
    [SerializeField] private DroneAtack _drone;
    [SerializeField] private GameObject _spawnPoint;
    private TextMeshProUGUI _canvasText;
    private string _canvasTextOld;
    private bool _canHide = true;
    private bool _showUI = true;
    private void Start()
    {
        if (_canvas != null)
        {
            _canvasText = _canvas.GetComponentInChildren<TextMeshProUGUI>();
            _canvasTextOld = _canvasText.text;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canvas.activeSelf && !_showUI)
        {
            HideInCloset();
        }
    }
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            if ((_canHide) &&(_showUI))
            {
                _showUI = false;
                _canvas.SetActive(true);
                _canvasText.text = "Спрятаться";
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        _canvas.SetActive(true);
        _showUI = false;
        if (_canHide)
        {
            _canvasText.text = "Спрятаться";
        }
        else
        {
            _canvasText.text = "Выйти из укрытия";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
        _canvasText.text = _canvasTextOld;
        _showUI = true;
    }
    private void HideInCloset()
    {
        if (_canHide)
        {
            if (_player != null)
            {
                _playerPosition = _player.transform.position;
                // _player.transform.Rotate(0, -88.351f, 0);
                _player.transform.rotation = gameObject.transform.rotation;
                _player.GetComponent<CapsuleCollider>().isTrigger = true;
                _cam.GetComponent<CameraController>().enabled = false;
                _player.GetComponent<PlayerController>().enabled = false;
                _player.GetComponentInChildren<Rigidbody>().isKinematic = true;
                _player.transform.position = _spawnPoint.transform.position;
                _canvas.SetActive(true);
                _canvasText.text = "Выйти из укрытия";
                _canHide = false;
                _drone.DroneToExit();
            }
        }
        else
        {
            if (_player != null)
            {
                _cam.GetComponent<CameraController>().enabled = true;
                _player.GetComponent<CapsuleCollider>().isTrigger = false;
                _player.GetComponentInChildren<Rigidbody>().isKinematic = false;
                _player.GetComponent<PlayerController>().enabled = true;
                _player.transform.rotation = gameObject.transform.rotation;
                _player.transform.position = _playerPosition;
                _canHide = true;
            }
        }
    }
}
