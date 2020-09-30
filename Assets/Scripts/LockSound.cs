using UnityEngine;

public class LockSound : MonoBehaviour
{

    private AudioSource audio;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(audio)
        {
            if (!audio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
