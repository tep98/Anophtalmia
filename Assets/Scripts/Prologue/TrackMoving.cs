using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackMoving : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject panel;
    private void Update()
    {
        Vector3 position = new Vector3(transform.position.x, 2.6f, transform.position.z);

        transform.position = Vector3.MoveTowards(position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
