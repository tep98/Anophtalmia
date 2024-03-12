using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float delay;

    private void Start()
    {
        Destroy(gameObject, delay);
    }
}
