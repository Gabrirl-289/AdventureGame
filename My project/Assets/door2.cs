using UnityEngine;
using UnityEngine.Playables; // Needed for Timeline

public class door2 : MonoBehaviour
{
    public Animator timelineDirector;
    public GameObject doorllider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && card2triger.hasCard2)
        {
            doorllider.SetActive(false);
            if (timelineDirector != null)
            {
                timelineDirector.SetBool("Open", true);

            }
        }
    }
}