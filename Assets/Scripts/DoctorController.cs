using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;

    private void Update()
    {
        Vector3 rotation = new Vector3(-19.936f, transform.rotation.y, transform.rotation.z);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, player.transform.position, speed * Time.deltaTime, 0f);
    
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
