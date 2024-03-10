using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private bool _explosed = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _explosed)
        {
            //exlosive
            _canvas.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_explosed) _canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
    }
}
