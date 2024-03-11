using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private AudioSource _shotGunShot;
    [SerializeField] private AudioSource _shotGunReload;
    [SerializeField] private GameObject _object;

    public void PlayShot()
    {
        _particles.Play();
        _shotGunShot.Play();
    }

    public void PlayReload()
    {
        _shotGunReload.Play();
    }

    public void ObjectSetActive()
    {
        _object.SetActive(true);
    }
}
