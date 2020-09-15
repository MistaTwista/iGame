using UnityEngine;

public class WastedScript : MonoBehaviour
{
    public GameObject respawn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawn.transform.position;
        }
    }
}
