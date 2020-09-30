using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, ITouch
{
    public GameObject particleSys;
    public Sprite[] particles;

    public GameObject soundFX;
    public AudioClip audio;

    // private void OnMouseDown()
    // {
    //     int x = (int)gameObject.transform.position.x;
    //     int y = (int)gameObject.transform.position.y;
    //     gameObject.GetComponent<LockRegister>().bomb(x, y);
    //     Destroy(gameObject);
    // }

    public void OnTouchBegan()
    {
        int x = (int)gameObject.transform.position.x;
        int y = (int)gameObject.transform.position.y;
        gameObject.GetComponent<LockRegister>().bomb(x, y);
        Sound(audio);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        particleSys = Instantiate(particleSys);
        particleSys.GetComponent<LockParticle>().sprites = particles;
        particleSys.transform.position = gameObject.transform.position;
    }

    private void Sound(AudioClip audio)
    {
        GameObject audioClone = Instantiate(soundFX);
        audioClone.GetComponent<AudioSource>().clip = audio;
        audioClone.GetComponent<AudioSource>().volume = 0.6f;
        audioClone.GetComponent<AudioSource>().Play();
    }
}
