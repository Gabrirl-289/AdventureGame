using UnityEngine;
using UnityEngine.UI; // Needed for UI

public class Interagir : MonoBehaviour
{
    public float interactionDistance = 2.5f;
    public GameObject player;
    public GameObject interactUI; // Assign a UI GameObject (e.g., a Text or Panel) in the Inspector

    private void Start()
    {
        if (interactUI != null)
            interactUI.SetActive(false);
    }

    private void Update()
    {
        if (IsMouseOver() && IsPlayerClose())
        {
            if (interactUI != null)
                interactUI.SetActive(true);
        }
        else
        {
            if (interactUI != null)
                interactUI.SetActive(false);
        }
    }

    private bool IsMouseOver()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D col = GetComponent<Collider2D>();
        return col != null && col.OverlapPoint(mousePos);
    }

    private bool IsPlayerClose()
    {
        if (player == null) return false;
        float dist = Vector2.Distance(player.transform.position, transform.position);
        return dist <= interactionDistance;
    }
}
