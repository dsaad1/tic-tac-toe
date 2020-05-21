using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PingPongMovment : MonoBehaviour
{

    [SerializeField] bool useLocalSpace;
    [SerializeField] bool move;
    [Header("range of movement")]
    public float min;
    public float max;
    [Header("speed properties")]
    public float moveSpeed;
    [Header("direction properties")]
    public Vector3 dir;

    float startSpeed;


    private void OnEnable()
    {
        if (move)
            Go();
    }

    void MoveA()
    {
        transform.DOLocalMoveX(min, moveSpeed).SetEase(Ease.InOutSine).OnComplete(() => MoveB());
    }

    void MoveB()
    {
        transform.DOLocalMoveX(max, moveSpeed).SetEase(Ease.InOutSine).OnComplete(() => MoveA());
    }

    private void OnDisable()
    {
        ResetSpeed();
        Stop();
    }

    public void Go()
    {
        MoveA();
    }

    public void Go(float seconds)
    {
        Invoke("Go", seconds);
    }

    public void Stop()
    {
        transform.DOKill();
        CancelInvoke();
    }

    public void Stop(float seconds)
    {
        Invoke("Stop", seconds);
    }

    public void SetSpeed(float aSpeed)
    {
        moveSpeed = aSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = startSpeed;
    }

    public void SetDir(Vector3 aDir)
    {
        dir = aDir;
    }


}
