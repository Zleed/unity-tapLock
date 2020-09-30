using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockParticle : MonoBehaviour
{
    private ParticleSystem ps;
    public Sprite[] sprites { get; set; }

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        foreach (Sprite sprite in sprites)
            ps.textureSheetAnimation.AddSprite(sprite);
    }

    void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
