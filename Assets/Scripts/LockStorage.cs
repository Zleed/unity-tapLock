using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Locks", menuName = "Locks")]
public class LockStorage : ScriptableObject
{
    public List<GameObject> locks;
}
