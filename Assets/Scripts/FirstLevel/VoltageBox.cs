using UnityEngine;

public class VoltageBox : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _canvas2;
    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _flashlight;
    [SerializeField] private BoxCollider _trigger;
    [SerializeField] private AudioSource _ElectroSound;

    private bool _beforeOpen = false;
    private bool _opened = false;

    private void Awake()
    {
        _trigger = gameObject.GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _opened)
        {
            _light.SetActive(true);
            _ElectroSound.Play();
            _flashlight.SetActive(false);
            _canvas2.SetActive(false);
            _opened = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && _beforeOpen)
        {
            _animator.SetTrigger("Open");
            _canvas.SetActive(false);
            _canvas2.SetActive(true);
            _opened = true;
            _beforeOpen = false;
            _trigger.enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_beforeOpen && _opened) _canvas.SetActive(false);
            if (_beforeOpen) _canvas.SetActive(true);
            _beforeOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
         _canvas.SetActive(false);
        _canvas2.SetActive(false);
    }
}
