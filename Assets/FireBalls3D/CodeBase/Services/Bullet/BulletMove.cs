using System.Collections;
using System.Collections.Generic;
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
}
