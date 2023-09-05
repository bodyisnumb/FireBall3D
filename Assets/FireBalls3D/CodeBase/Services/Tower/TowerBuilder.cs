using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int towerSize;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject blockPrefab;

    public Queue<Block> BuildTower()
    {
        Queue<Block> blocks = new Queue<Block>();
        Transform currentPoint = spawnPoint;

        for (int i = 0; i < towerSize; i++)
        {
            Block tempBlock = Build(currentPoint);
            currentPoint = tempBlock.transform;
            blocks.Enqueue(tempBlock);

        }
        
            return blocks;
    }

    private Block Build(Transform currentBuildPoint)
    {
        Block block = Instantiate(blockPrefab, GetBuildPoint(currentBuildPoint), Quaternion.identity, spawnPoint).GetComponent<Block>();

        return block;
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(currentSegment.position.x, currentSegment.position.y + currentSegment.localScale.y / 2f + blockPrefab.transform.localScale.y / 2.5f,
         currentSegment.position.z);

        
    }

}
