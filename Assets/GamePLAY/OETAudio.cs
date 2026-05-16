using UnityEngine;

public class OETAudio : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
} //simply done like that boom