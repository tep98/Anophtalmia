using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canvas.activeSelf)
        {
            SceneManager.LoadScene("SecondLevel");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
    }
}
