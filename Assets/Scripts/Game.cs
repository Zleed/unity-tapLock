
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject multiTouch;
    public GameObject wall;
    public GameObject menu;
    public GameObject restart;
    public LockStorage lockStorage;
    public GameObject score;
    private LockRegister LockRegister;
    private static float gameSpeed = 0.8f;
    private static float freez = 0;
    private static int gameCount = 0;

    private float time;

    private void Start()
    {
        GoogleMobileAdsScript.HideBannerAd();

        LockRegister = lockStorage.locks[0].GetComponent<LockRegister>();

        multiTouch = Instantiate(multiTouch);
        multiTouch.GetComponent<MultiTouch>().lockRegister = LockRegister;

        restart = Instantiate(restart);
        restart.GetComponent<Restart>().game = gameObject;

        score = Instantiate(score);

        wall = Instantiate(wall);

        SpawnLock();
    }

    private void Update()
    {
        time += Time.deltaTime;
        LockRegister.UpdateBoard();
        freez -= 1 * Time.deltaTime;
        if (time > gameSpeed && freez <= 0)
        {
            time = 0;
            SpawnLock();
        }
    }

    private void OnDestroy()
    {
        if (++gameCount == 5)
        {
            GoogleMobileAdsScript.ShowInterstitial();
            gameCount = 0;
        }
        LockRegister.DestroyBoard();
        Destroy(score);
        Destroy(restart);
        Destroy(multiTouch);
        Destroy(wall);
        Instantiate(menu);
    }

    public void SpawnLock()
    {
        int chance = 0;
        int randomInt = (Random.Range(1, 101));
        List<float> FreeColumnCords = LockRegister.GetFreeColumnCords();

        foreach (GameObject Lock in lockStorage.locks)
        {
            chance += (int)Lock.GetComponent<LockTypeManager>().lockType;
            if (randomInt <= chance)
            {
                if (FreeColumnCords.Count != 0)
                {
                    Instantiate(Lock, new Vector2(FreeColumnCords[Random.Range(0, FreeColumnCords.Count)], 8.5f), Quaternion.identity);
                    return;
                }
              
                else Destroy(gameObject);
            }
        }
    }

    public static void Freez()
    {
        freez = 5;
    }
}
