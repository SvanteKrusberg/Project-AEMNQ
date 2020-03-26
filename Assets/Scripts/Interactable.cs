using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    bool isFocused = false;
    Transform player;

    bool hasInteracted = false;

    void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocused = false;
        hasInteracted = false;
        player = null;
    }

    public virtual void Interact()
    {
        Debug.Log("interacting with " + transform.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
