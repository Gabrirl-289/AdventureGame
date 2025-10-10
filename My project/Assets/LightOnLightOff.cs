using UnityEngine;

public class LightOnLightOff : MonoBehaviour
{
    public GameObject loight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            loight.SetActive(!loight.activeSelf);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            loight.SetActive(true);
        }
    }
}
