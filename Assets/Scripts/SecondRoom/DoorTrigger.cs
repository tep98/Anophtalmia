using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Type{ Left, Front, Right, Back };

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Transform _player;
    [SerializeField] private Type _type;
    [SerializeField] private Transform _virtualCamera;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(Paper.count != 3)
                {
                    RoomSwitch();
                }
                else
                {
                    SceneManager.LoadScene("ThirdScene");
                }
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
    }
    private void RoomSwitch()
    {
        if (_type == Type.Front)
        {
            _player.position = new Vector3(_player.position.x, _player.position.y, _player.position.z + 6f);
            _virtualCamera.position = new Vector3(_virtualCamera.position.x, _virtualCamera.position.y, _virtualCamera.position.z + 12f);
        }
        else if (_type == Type.Left)
        {
            _player.position = new Vector3(_player.position.x - 6f, _player.position.y, _player.position.z);
            _virtualCamera.position = new Vector3(_virtualCamera.position.x - 12f, _virtualCamera.position.y, _virtualCamera.position.z);
        }
        else if (_type == Type.Back)
        {
            _player.position = new Vector3(_player.position.x, _player.position.y, _player.position.z - 6f);
            _virtualCamera.position = new Vector3(_virtualCamera.position.x, _virtualCamera.position.y, _virtualCamera.position.z - 12f);
        }
        else if (_type == Type.Right)
        {
            _player.position = new Vector3(_player.position.x + 6f, _player.position.y, _player.position.z);
            _virtualCamera.position = new Vector3(_virtualCamera.position.x + 12f, _virtualCamera.position.y, _virtualCamera.position.z);
        }
    }
}
