using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerBuilder builder;
    private Queue<Block> _blocks;

    private void Start()
    {
        _blocks = builder.BuildTower();


        foreach (var block in _blocks)
        {
            block.BulletTouched += BulletHit;
        }
    }

    private void BulletHit(Block block)
    {
        block.BulletTouched -= BulletHit;
        _blocks.Dequeue();
        foreach (var myblock in _blocks)
        {
            myblock.transform.position = new Vector3(myblock.transform.position.x, myblock.transform.position.y - myblock.transform.localScale.y / 1.12f, myblock.transform.position.z);
        }
    }
}
