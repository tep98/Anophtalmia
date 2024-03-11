using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextChangerFinalRoom : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Animator anim;
    [SerializeField] private DoctorController DC;
    private int currentObject;

    private void Start()
    {
        currentObject = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentObject < gameObjects.Length)
            {
                gameObjects[currentObject].SetActive(true);
                gameObjects[currentObject - 1].SetActive(false);
                currentObject++;
            }
            if (currentObject == gameObjects.Length)
            {
                anim.SetTrigger("GetGun");
                DC.enabled = false;
            }
        }
    }
}
