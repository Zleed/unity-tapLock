using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolveEffect : MonoBehaviour
{

    public Material material;
    private float dissolveAmount;

    private bool isDissolving = true;

    private void Start()
    {
        material.SetFloat("_DissovleAmount", 0);
    }

    private void Update()
    {
        if (isDissolving)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount + Time.deltaTime * 2);
            material.SetFloat("_DissovleAmount", dissolveAmount);
            if (dissolveAmount == 1) isDissolving = false;
        }
    }

    private void OnDestroy()
    {
        material.SetFloat("_DissovleAmount", 0);
    }

}
