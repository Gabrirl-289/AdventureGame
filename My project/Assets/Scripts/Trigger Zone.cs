using UnityEngine;
using UnityEngine.Events;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public UnityEvent onEnter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onEnter.Invoke();
    }
}
