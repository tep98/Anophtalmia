using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _bombPlace;

    [SerializeField] private GameObject _child1;
    [SerializeField] private GameObject _child2;
    public GameObject hand;

    public bool OnHand = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canvas.activeSelf)
        {
            hand.SetActive(true);
            OnHand = true;
            _child1.SetActive(false);
            _child2.SetActive(false);
            _canvas.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!OnHand) _canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas.SetActive(false);
    }
}
