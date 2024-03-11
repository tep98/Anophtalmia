using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _paperCanvas;
    [SerializeField] private GameObject _player;

    public static int count = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canvas.activeSelf)
        {
            _paperCanvas.SetActive(true);
            _player.GetComponent<PlayerController>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _canvas.activeSelf)
        {
            _player.GetComponent<PlayerController>().enabled = true;
            _paperCanvas.SetActive(false);
            count++;
            Destroy(gameObject);
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
