using UnityEngine;

public class SoundManager : MonoBehaviour
{
 
    public AudioClip shootSound;
    private AudioSource audioSource;
    void Start()
    {
       audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            playShootSound();
        }
    }
    public void playShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }
}
