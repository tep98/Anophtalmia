using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject[] _cameras;
    [SerializeField] private int[] _resolutions;

    private Rigidbody _rb;
    RaycastHit _hit;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RandomCamera();
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);


/*        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out _hit);
        Vector3 targetPosition = new Vector3(_hit.point.x, transform.position.y, _hit.point.z + 2.3f);
        transform.LookAt(targetPosition);*/

        _rb.MovePosition(transform.position + move.normalized * _moveSpeed * Time.deltaTime);
        _animator.SetFloat("Horizontal", x);
        _animator.SetFloat("Vertical", z);
    }

    private void RandomCamera()
    {
        _cameras[0].SetActive(false);
        _cameras[1].SetActive(false);
        _cameras[2].SetActive(false);
        _cameras[Random.Range(0,3)].SetActive(true);
    }
}
