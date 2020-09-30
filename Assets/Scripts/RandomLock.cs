
using UnityEngine;

public class RandomLock : MonoBehaviour, ITouch
{
    public LockStorage lockStorage;
    private GameObject randomLock;

    public GameObject particleSys;
    public Sprite[] particles;

    public GameObject soundFX;
    public AudioClip audio;

    void Start()
    {
        randomLock = lockStorage.locks[Random.Range(0, lockStorage.locks.Count)];
    }

    //private void OnMouseDown()
    //{
    //    int x = (int)gameObject.transform.position.x;
    //    int y = (int)gameObject.transform.position.y;
    //    Particles();
    //    gameObject.transform.position = new Vector2(0f, -15f);
    //    Instantiate(randomLock, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity);
    //    Destroy(gameObject);
    //}

    public void OnTouchBegan()
    {
        int x = (int)gameObject.transform.position.x;
        int y = (int)gameObject.transform.position.y;
        Particles();
        gameObject.transform.position = new Vector2(0f, -15f);
        Instantiate(randomLock, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity);
        Sound(audio);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Particles();
    }

    private void Particles()
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
