using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Lightsource2D : MonoBehaviour
{
    public int maxBounces = 5;
    public float maxDistance = 100f;

    private LineRenderer lineRenderer;
    public LayerMask reflectLayerMask;
    public GameObject colliderBox;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        CastLight();
    }

    void CastLight()
    {
        Vector2 direction = transform.right;
        Vector2 position = transform.position;

        List<Vector3> points = new List<Vector3> { position };

        for (int i = 0; i < maxBounces; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(position, direction, maxDistance, reflectLayerMask);
            if (hit.collider != null)
            {
                points.Add(hit.point);

                if (hit.collider.CompareTag("Mirror"))
                {
                    direction = Vector2.Reflect(direction, hit.normal);
                    position = hit.point + direction * 0.01f; // Slight offset to avoid same point bouncing
                }
                else if (hit.collider.CompareTag("Crystal"))
                {
                    Debug.Log("Puzzle Complete! Light reached the crystal.");
                    points.Add(hit.point);
                    colliderBox.SetActive(false);
                    break;
                }
                else // Hit wall or obstacle
                {
                    points.Add(hit.point);
                    break;
                }
            }
            else
            {
                points.Add(position + direction * maxDistance);
                break;
            }
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
