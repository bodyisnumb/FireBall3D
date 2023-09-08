using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyParticle;
    public Action<Block> BulletTouched;
    public void Break()
    {
        Instantiate(destroyParticle, transform.position, Quaternion.identity);
        BulletTouched?.Invoke(this);
        Destroy(gameObject);
    }
}
