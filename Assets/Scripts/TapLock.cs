using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapLock : MonoBehaviour, ITouch
{
    public Sprite[] sprites = new Sprite[2];
    private SpriteRenderer sr;
    private int life;
    private int tick;

    public GameObject particleSys;
    public GameObject particleSysClone;
    public Sprite[] particles;

    public GameObject soundFX;
    public AudioClip[] audio;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        life = Random.Range(1, 10);
    }

    private void Update()
    {
        if (tick++ == 5) sr.sprite = sprites[0];
    }

    //[System.Obsolete]
    //private void OnMouseDown()
    //{
    //    tick = 0;
    //    sr.sprite = sprites[1];
    //    if (--life == 0)
    //    {
    //        Score.UpdateScore();
    //        Destroy(gameObject);
    //    }
    //    Particles(2);
    //}

    [System.Obsolete]
    public void OnTouchBegan()
    {
        tick = 0;
        sr.sprite = sprites[1];
        if (--life == 0)
        {
            Score.UpdateScore();
            Sound(audio[0]);
            Destroy(gameObject);
        }
        Sound(audio[1]);
        Particles(2);
    }

    [System.Obsolete]
    private void OnDestroy()
    {
        Particles(10);
    }

    [System.Obsolete]
    private void Particles(int quantity)
    {
        particleSysClone = Instantiate(particleSys);
        particleSysClone.GetComponent<LockParticle>().sprites = particles;
        particleSysClone.GetComponent<ParticleSystem>().maxParticles = quantity;
        particleSysClone.transform.position = gameObject.transform.position;
    }

    private void Sound(AudioClip audio)
    {
        GameObject audioClone = Instantiate(soundFX);
        audioClone.GetComponent<AudioSource>().clip = audio;
        audioClone.GetComponent<AudioSource>().Play();
    }
}
