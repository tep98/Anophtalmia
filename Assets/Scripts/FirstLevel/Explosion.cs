using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _placeCanvas;
    [SerializeField] private GameObject _explosiveCanvas;
    [SerializeField] private Bomb _bomb;
    [SerializeField] private GameObject _placedBomb;

    [Header("Explode")]
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private GameObject _explosionEffect;

    private bool _placed = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _placeCanvas.activeSelf)
        {
            _bomb.hand.SetActive(false);
            _bomb.OnHand = false;
            _placedBomb.SetActive(true);
            _placed = true;
            _placeCanvas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && _explosiveCanvas.activeSelf)
        {
            Explode();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_bomb.OnHand) _placeCanvas.SetActive(true);
            if (_placed) _explosiveCanvas.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _placeCanvas.SetActive(false);
        if (_placed) _explosiveCanvas.SetActive(true);
    }


    private void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
                
            }
        }
        _placedBomb.SetActive(false);
        Destroy(gameObject);
        _explosiveCanvas.SetActive(false);
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
