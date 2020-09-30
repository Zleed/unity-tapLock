using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freez : MonoBehaviour, ITouch
{
    public GameObject particleSys;
    public Sprite[] particles;

    public GameObject soundFX;
    public AudioClip audio;

    //private void OnMouseDown()
    //{
    //    Game.Freez();
    //    Destroy(gameObject);
    //}

    public void OnTouchBegan()
    {
        Game.Freez();
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
        audioClone.GetComponent<AudioSource>().Play();
    }
}
