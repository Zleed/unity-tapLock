
using System.Collections;
using UnityEngine;

public class ClockLock : MonoBehaviour, ITouch
{
    private LockTypeManager lockTypeManager;
    private SpriteRenderer sr;

    private static Sprite[][] sprites = new Sprite[3][];
    public Sprite[] sprites1;
    public Sprite[] sprites2;
    public Sprite[] sprites3;

    public GameObject particleSys;
    private GameObject particleSysClone;
    private Sprite[][] particles = new Sprite[4][];
    public Sprite[] greyParticles;
    public Sprite[] greenParticles;
    public Sprite[] yellowParticles;
    public Sprite[] redParticles;

    private int life;
    private static int c = 0;
    private float time = 5f;

    public GameObject soundFX;
    public AudioClip[] sounds;
    private bool GreyFlag = true;

    private void Start()
    {
        this.name = (++c).ToString();
        lockTypeManager = gameObject.GetComponent<LockTypeManager>();
        lockTypeManager.lockType = LockType.CLOCKLOCK;
        sr = GetComponent<SpriteRenderer>();
        SetUpSprites();
        SetLife(50, 40, 10);
    }

    private void Update()
    {
        UpdateSprite();
    }

    private void OnDestroy()
    {
        Particles();
    }

    //private void OnMouseDown()
    //{
    //    if ((int)time == 1)
    //    {
    //        Score.UpdateScore();
    //        Sound(sounds[0]);
    //        if (life - 1 == 0)
    //        {
    //            Destroy(gameObject);
    //            return;
    //        }
    //        time = 5f;
    //        Particles();
    //        life--;
    //    }
    //    else time = 0;
    //}

    public void OnTouchBegan()
    {
        if ((int)time == 1)
        {
            Score.UpdateScore();
            Sound(sounds[0]);
            if (life - 1 == 0)
            {
                Destroy(gameObject);
                return;
            }
            time = 5f;
            Particles();
            life--;
        }
        else time = 0;
    }

    private void SetUpSprites()
    {
        sprites[0] = sprites1;
        sprites[1] = sprites2;
        sprites[2] = sprites3;
        particles[0] = greyParticles;
        particles[1] = greenParticles;
        particles[2] = yellowParticles;
        particles[3] = redParticles;
    }

    private void UpdateSprite()
    {
        if (time >= 0)
        {
            time -= 1 * Time.deltaTime;
            int i = (life - 1 < 0) ? 0 : life - 1;
            sr.sprite = sprites[i][(int)time];
            if (time < 1)
            {
                lockTypeManager.lockType = LockType.GREYLOCK;
                if (GreyFlag)
                {
                    Sound(sounds[1]);
                    GreyFlag = false;
                }
            }
        }
    }

    private void SetLife(int green, int yellow, int red)
    {
        yellow += green;
        red += yellow;
        int r = Random.Range(1, 101);

        if (r <= green)
        {
            life = 1;
        }
        else if (r <= yellow)
        {
            life = 2;
        }
        else if (r <= red)
            life = 3;
    }

    private void Particles()
    {
        int i = (time < 1) ? 0 : life;
        particleSysClone = Instantiate(particleSys);
        particleSysClone.GetComponent<LockParticle>().sprites = particles[i];
        particleSysClone.transform.position = gameObject.transform.position;
    }

    private void Sound(AudioClip audio)
    {
        GameObject audioClone = Instantiate(soundFX);
        audioClone.GetComponent<AudioSource>().clip = audio;
        audioClone.GetComponent<AudioSource>().Play();
    }

}
