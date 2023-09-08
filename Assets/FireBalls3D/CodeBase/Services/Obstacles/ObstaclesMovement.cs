using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    [SerializeField] private float rotateTime;

    private Tween _rotateAnimation;

    private void Start()
    {
        StartMovement();
    }

    public void StartMovement()
    {
      _rotateAnimation = transform.DORotate(new Vector3(0, 360, 0), rotateTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }

    public void StopMovement()
    {
        _rotateAnimation.Pause();
    }
}
