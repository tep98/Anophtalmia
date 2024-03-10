using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                 SceneManager.LoadScene("SecondLevel");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
    }
}
