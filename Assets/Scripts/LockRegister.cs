
using System.Collections.Generic;
using UnityEngine;

public class LockRegister : MonoBehaviour
{
    private static List<GameObject> Locks = new List<GameObject>();
    private static GameObject[,] GameBoard = new GameObject[4, 8];

    public void Start()
    {
        Locks.Add(gameObject);
    }

    public void OnDestroy()
    {
        Locks.Remove(gameObject);
    }

    public void UpdateBoard()
    {
        GameBoard = new GameObject[4, 8];

        foreach (GameObject Lock in Locks)
        {
            int x = (int)Lock.transform.position.x;
            int y = (int)Lock.transform.position.y;
            try
            {
                GameBoard[x, y] = Lock;
            }
            catch (System.IndexOutOfRangeException) { }
        }
    }

    public List<float> GetFreeColumnCords()
    {
        float[] burnedCords = { 0.5f, 1.5f, 2.5f, 3.5f };
        List<float> freeColumns = new List<float>();

        for (int x = 0; x < 4; x++)
        {
            int count = 0;
            for (int y = 0; y < 8; y++)
            {
                if (GameBoard[x, y] != null) count++;
                else break;
            }
            if (count < 8) freeColumns.Add(burnedCords[x]);
        }
        return freeColumns;
    }

    public void DestroyBoard()
    {
        foreach (GameObject Lock in Locks)
        {
            Destroy(Lock);
        }
    }

    public void bomb(int x, int y)
    {
        int[] xDif = { 0, 1, 1, 1, 0, -1, -1, -1 };
        int[] yDif = { 1, 1, 0, -1, -1, -1, 0, 1 };
        for (int i = 0; i < 8; i++)
        {
            try
            {
                GameObject Lock = GameBoard[x + xDif[i], y + yDif[i]];
                if (Lock.GetComponent<LockTypeManager>().lockType != LockType.CLOCKLOCK) Destroy(Lock);
            }
            catch (System.NullReferenceException) { }
            catch (System.IndexOutOfRangeException) { }
        }
    }

    public GameObject GetLock(Vector2 touchPos)
    {
        int x = (int)touchPos.x;
        int y = (int)touchPos.y;
        return GameBoard[x, y];
    }

}
