using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type{ Left, Front, Right, Back };

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Transform _player;
    [SerializeField] private Type _type;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                RoomSwitch();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
    }
    private void RoomSwitch()
    {
        if(_type == Type.Front)
        {
            _player.position = new Vector3(_player.position.x, _player.position.y, _player.position.z + 12.5f) ;
        }
        else if (_type == Type.Left)
        {
            _player.position = new Vector3(_player.position.x - 12.5f, _player.position.y, _player.position.z);
        }
        else if (_type == Type.Back)
        {
            _player.position = new Vector3(_player.position.x, _player.position.y, _player.position.z - 12.5f);
        }
        else if (_type == Type.Right)
        {
            _player.position = new Vector3(_player.position.x + 12.5f, _player.position.y, _player.position.z);
        }
    }
}
