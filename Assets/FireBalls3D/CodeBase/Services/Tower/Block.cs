using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Action<Block> BulletTouched;
    public void Break()
    {
        BulletTouched?.Invoke(this);
        Destroy(gameObject);
    }
}
