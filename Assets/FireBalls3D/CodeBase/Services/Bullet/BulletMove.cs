using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidBody;
    [SerializeField] private float moveSpeed = 1f;

    public void MoveTo(Transform startTransform, Vector3 moveDirection)
    {
        transform.position = startTransform.position;
        myRigidBody.velocity = moveDirection * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Block>(out Block towerBlock))
        {
            towerBlock.Break();
            Destroy(gameObject);
        }

        else if(other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }

        else if(other.TryGetComponent(out PlayerShoot player))
        {
            player.GameOver();
            Destroy(gameObject);
        }
    }

    private void Bounce()
    {
        myRigidBody.velocity *= -1;
    }


}
