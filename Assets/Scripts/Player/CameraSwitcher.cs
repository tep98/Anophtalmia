using Assets.Pixelation.Scripts;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject[] cameras;

    private void Awake()
    {
        RandomCamera();
    }
    private void RandomCamera()
    {
        DisableCameras();
        cameras[Random.Range(0, cameras.Length - 1)].SetActive(true);
        Camera.main.GetComponent<Pixelation>().BlockCount = Random.Range(200.0f, 512.0f);
        //—юда добавить код дл€ запуска эффекта глитчей

        Invoke("RandomCamera", Random.Range(4f, 10f));
    }

    public void DisableCameras()
    {
        for (int i = 0; i < cameras.Length - 1; i++)
        {
            cameras[i].SetActive(false);
        }
    }
}
