using UnityEngine;

public class errorTest : MonoBehaviour
{
    [Header("Vision Settings")]
    public float viewRadius = 5f;               // How far the enemy can see
    [Range(0, 360)]
    public float viewAngle = 90f;               // The width of the vision cone in degrees
    public float visionThickness = 0.3f;        // How "wide" the enemy’s vision ray is
    public LayerMask playerMask;                // Player layer
    public LayerMask obstacleMask;              // Walls or obstacles

    [Header("Detection")]
    public bool playerInSight;                  // True if player is visible
    private Transform player;

    void Start()
    {
        // Automatically find player if tagged "Player"
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        playerInSight = false;

        if (player == null)
            return;

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if player is within view radius
        if (distanceToPlayer < viewRadius)
        {
            // Check if player is within view angle
            float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer);
            if (angleToPlayer < viewAngle / 2)
            {
                // Cast a thicker "vision" ray (like a short cone)
                RaycastHit2D hit = Physics2D.CircleCast(transform.position, visionThickness, directionToPlayer, distanceToPlayer, obstacleMask | playerMask);
                if (hit.collider != null)
                {
                    // If hit player before wall
                    if (((1 << hit.collider.gameObject.layer) & playerMask) != 0)
                    {
                        playerInSight = true;
                        Debug.DrawLine(transform.position, player.position, Color.green); // See player
                    }
                    else
                    {
                        Debug.DrawLine(transform.position, hit.point, Color.red); // Blocked by wall
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 rightDir = Quaternion.Euler(0, 0, viewAngle / 2) * transform.right;
        Vector3 leftDir = Quaternion.Euler(0, 0, -viewAngle / 2) * transform.right;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + rightDir * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + leftDir * viewRadius);
    }
}
