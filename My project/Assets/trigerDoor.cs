using UnityEngine;
using UnityEngine.Playables; // Needed for Timeline

public class triggerDoor : MonoBehaviour
{
    public  Animator timelineDirector;
    public GameObject doorcollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cardScript.hasCard)
        {
            doorcollider.SetActive(false);
            if (timelineDirector != null)
            {
                timelineDirector.SetBool("Open", true);
               
            }
        }
    }
}