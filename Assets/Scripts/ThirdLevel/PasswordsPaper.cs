using UnityEngine;

public class PasswordsPaper : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _passwordCanvas;
    [SerializeField] private PaperManager _parent;
    [SerializeField] private GameObject _player;
    public static int count = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canvas.activeSelf)
        {
            _passwordCanvas.SetActive(true);
            _player.GetComponent<PlayerController>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _canvas.activeSelf)
        {
            _player.GetComponent<PlayerController>().enabled = true;
            _passwordCanvas.SetActive(false);
            count++;
            _parent.EnablePaper(count);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
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
