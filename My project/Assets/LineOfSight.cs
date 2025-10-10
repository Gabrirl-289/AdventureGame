using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Rendering;

public class LineOfSight : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    private float startingAngle;
    private Vector3 origin;
    private float fov = 90f;
    private void Start()
    {
        origin = Vector3.zero;

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Update()
    { 

        float fov = 90f;
       // Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex; 
           RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, getVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
               // no hit
                vertex = origin + getVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // hit object
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
            
        }

        //vertices[0] = Vector3.zero;
        //vertices[1] = new Vector3(50,0);
        //vertices[2] = new Vector3(0,-50);

        //triangles[0] = 0;
        //triangles[1] = 1;
        //triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public static Vector3 getVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public static float getAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = getAngleFromVectorFloat(aimDirection) - fov/2f;
    }
}


