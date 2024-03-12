using Assets.Pixelation.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private int[] _resolutions;
    
    private Rigidbody _rb;
    private Camera _cam;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = _cam.transform.forward;
        Vector3 right = _cam.transform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 move = (forward * z + right * x).normalized;

        _rb.MovePosition(transform.position + move * _moveSpeed * Time.deltaTime);

        _animator.SetFloat("Horizontal", x);
        _animator.SetFloat("Vertical", z);
    }
}
