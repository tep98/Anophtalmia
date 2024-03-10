using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    [SerializeField] private GameObject track;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            track.SetActive(true);
        }
    }
}
