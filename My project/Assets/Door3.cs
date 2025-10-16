using UnityEngine;
using UnityEngine.Playables; // Needed for Timeline

public class door3 : MonoBehaviour
{
    public Animator timelineDirector;
    public GameObject doorcllider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && card3trigger.hasCard3)
        {
            doorcllider.SetActive(false);
            if (timelineDirector != null)
            {
                timelineDirector.SetBool("Open", true);

            }
        }
    }
}
