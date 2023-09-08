using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TowerBuilder builder;
    private Queue<Block> _blocks;

    private int _gameScore;

    private void Start()
    {
        BuildTower();
    }

    private void BulletHit(Block block)
    {
        block.BulletTouched -= BulletHit;
        _blocks.Dequeue();

        foreach (var myblock in _blocks)
        {
            myblock.transform.position = new Vector3(myblock.transform.position.x, myblock.transform.position.y - myblock.transform.localScale.y / 1.12f, myblock.transform.position.z);
        }

        _gameScore++;
        scoreText.text = _gameScore.ToString();

        if(_blocks.Count <= 0)
        {
            BuildTower();
        }
    }

    private void BuildTower()
    {
        _blocks = builder.BuildTower();


        foreach (var block in _blocks)
        {
            block.BulletTouched += BulletHit;
        }
    }
}
