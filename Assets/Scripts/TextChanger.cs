using UnityEngine;
using UnityEngine.SceneManagement;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    private int currentObject;

    private void Start()
    {
        currentObject = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentObject<gameObjects.Length)
            {
                gameObjects[currentObject].SetActive(true);
                gameObjects[currentObject - 1].SetActive(false);
                currentObject++;
            }
            else
            {
                SceneManager.LoadScene("FirstLevel");
            }
        }
    }
}
