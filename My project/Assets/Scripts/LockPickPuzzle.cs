using UnityEngine;

public class LockPickPuzzle : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public int totalPins = 3;
    public float tolerance = 10f;
    public float rotationSpeed = 60f;

    [Header("References")]
    public Transform lockpickVisual; // Drag your Lockpick sprite here

    [Header("Debug")]
    public float currentAngle = 0f;
    private int currentPin = 0;
    private float[] pinAngles;
    private bool[] pinSolved;

    private bool puzzleComplete = false;

    void Start()
    {
        pinAngles = new float[totalPins];
        pinSolved = new bool[totalPins];

        for (int i = 0; i < totalPins; i++)
        {
            pinAngles[i] = Random.Range(0f, 360f);
        }
    }

    void Update()
    {
        if (puzzleComplete) return;

        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TrySolveCurrentPin();
        }

        UpdateLockpickVisual(); // Update visual after rotation
    }

    void HandleRotation()
    {
        float input = Input.GetAxis("Horizontal");
        currentAngle += input * rotationSpeed * Time.deltaTime;
        currentAngle = (currentAngle + 360f) % 360f;
    }

    void UpdateLockpickVisual()
    {
        if (lockpickVisual != null)
        {
            lockpickVisual.localRotation = Quaternion.Euler(0f, 0f, -currentAngle);
            // Negative because clockwise is negative in Unity 2D
        }
    }

    void TrySolveCurrentPin()
    {
        float target = pinAngles[currentPin];
        float diff = Mathf.Abs(Mathf.DeltaAngle(currentAngle, target));

        if (diff <= tolerance)
        {
            pinSolved[currentPin] = true;
            Debug.Log($"Pin {currentPin + 1} solved! ({currentAngle:F1}° ≈ {target:F1}°)");
            currentPin++;

            if (currentPin >= totalPins)
            {
                puzzleComplete = true;
                Debug.Log("✅ All pins aligned. Lock opened!");
            }
        }
        else
        {
            Debug.Log($"❌ Incorrect. Try again. (Need ≈ {target:F1}°, you hit {currentAngle:F1}°)");
        }
    }
}
