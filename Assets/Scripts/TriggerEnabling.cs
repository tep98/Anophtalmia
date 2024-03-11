using UnityEngine;

public class TriggerEnabling : MonoBehaviour
{
    [SerializeField] private GameObject currentObject;
    [SerializeField] private GameObject previousObject;
    [SerializeField] private float delay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("Activate", delay);
        }
    }

    private void Activate()
    {
        currentObject.SetActive(true);

        if (previousObject != null)
        {
            previousObject.SetActive(false);
        }
    }
}
