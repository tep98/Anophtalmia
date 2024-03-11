using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private int _number;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canvas.activeSelf)
        {
            if(_number == 2)
            {
                SceneManager.LoadScene("SecondLevel");
            }
            if (_number == 3)
            {
                SceneManager.LoadScene("FinalRoom");
            }

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
