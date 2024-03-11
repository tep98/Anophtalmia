using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    public void ObjectSetActive()
    {
        _object.SetActive(true);
    }
}
