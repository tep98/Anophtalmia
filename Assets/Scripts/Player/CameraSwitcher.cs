using Assets.Pixelation.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject[] cameras;

    private void RandomCamera()
    {
        DisableCameras();
        cameras[Random.Range(0, cameras.Length - 1)].SetActive(true);
        Camera.main.GetComponent<Pixelation>().BlockCount = Random.Range(64.0f, 512.0f);
        //—юда добавить код дл€ запуска эффекта глитчей

        Invoke("RandomCamera", Random.Range(5f, 10f));
    }

    public void DisableCameras()
    {
        for (int i = 0; i < cameras.Length - 1; i++)
        {
            cameras[i].SetActive(false);
        }
    }
}
