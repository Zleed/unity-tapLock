using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouch : MonoBehaviour
{
    private static GameObject Lock;

    public LockRegister lockRegister { get; set; }

    private static Dictionary<LockType, Action> functions = new Dictionary<LockType, Action>
        {
            { LockType.CLOCKLOCK, ClockLockBegan },
            { LockType.TAPLOCK, TapLockBegan },
            { LockType.FREEZ, FreezBegan },
            { LockType.BOMB, BombBegan },
            { LockType.RANDOM, RandomLockBegan }
        };

    private void Update()
    {
        for(int i = 0; i < Input.touchCount; i++) 
        {
            Touch touch = Input.touches[i];
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began) 
            {
                OnTouch(touchPos);
            }
        }
    }

    public void OnTouch(Vector2 touchPos)
    {
        Lock = lockRegister.GetLock(touchPos);
        LockType lockType = Lock.GetComponent<LockTypeManager>().lockType;
        functions[lockType].Invoke();
    }

    private static void ClockLockBegan()
    {
        Lock.GetComponent<ClockLock>().OnTouchBegan();
    }
    private static void TapLockBegan()
    {
        Lock.GetComponent<TapLock>().OnTouchBegan();
    }
    private static void FreezBegan()
    {
        Lock.GetComponent<Freez>().OnTouchBegan();
    }
    private static void BombBegan()
    {
        Lock.GetComponent<Bomb>().OnTouchBegan();
    }
    private static void RandomLockBegan()
    {
        Lock.GetComponent<RandomLock>().OnTouchBegan();
    }

}
