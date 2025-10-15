using Pathfinding;
using UnityEngine;

public class error : MonoBehaviour
{
    [Header("Vision Settings")]
    public float viewRadius = 5f;               // How far the enemy can see
    [Range(0, 360)]
    public float viewAngle = 90f;               // The width of the vision cone in degrees
    public LayerMask playerMask;                // Layer of the player
    public LayerMask obstacleMask;              // Layer of walls or obstacles

    [Header("Detection")]
    public bool playerInSight;                  // True if player is visible
    private Transform player;

    public AIDestinationSetter Ai;


    void Start()
    {
        // Optional: Automatically find the player by tag
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
            float angleToPlayer = Vector2.Angle(transform.up, directionToPlayer);
            if (angleToPlayer < viewAngle / 2)
            {
                // Check for walls between enemy and player
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask | playerMask);
                if (hit.collider != null)
                {
                    if (((1 << hit.collider.gameObject.layer) & playerMask) != 0)
                    {
                        playerInSight = true;
                        Ai.chasePlayer = true;
                        Debug.DrawLine(transform.position, player.position, Color.green); // Visible
                        Ai.target = player; // Set the AI's target to the player
                    }
                    else
                    {
                        Debug.DrawLine(transform.position, hit.point, Color.red); // Blocked by wall
                    }
                }
            }
        }
    }

    // Draw vision cone in the editor for debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 rightDir = Quaternion.Euler(0, 0, viewAngle / 2) * transform.up;
        Vector3 leftDir = Quaternion.Euler(0, 0, -viewAngle / 2) * transform.up;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + rightDir * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + leftDir * viewRadius);
    }
}
