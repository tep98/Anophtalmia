using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private GameObject _object;

    public void PlayParticles()
    {
        _particles.Play();
    }

    public void ObjectSetActive()
    {
        _object.SetActive(true);
    }
}
