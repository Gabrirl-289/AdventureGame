using UnityEngine;


//[ExecuteAlways]
public class Virus : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        virus();
    }

    private void virus() 
    { 
    Debug.Log("Virus activated");
    
    virus();
    }
}
