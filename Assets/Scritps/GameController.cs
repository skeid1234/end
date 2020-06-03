using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TrackableEventHandler Target;
    public GenBlockController genBlockLeft;
    public GenBlockController genBlockRight;

    private void Start()
    {
        Target.TargetEvent += GameStart;
    }

    private void GameStart(bool arg1, GameObject arg2)
    {
        if (arg1)
        {
            genBlockLeft.EnableGenProcess();
            genBlockRight.EnableGenProcess();
        }
        else
        {
            genBlockLeft.DisableGenProcess();
            genBlockRight.DisableGenProcess();
        }
    }
}
