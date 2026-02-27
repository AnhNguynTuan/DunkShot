using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NetController : MonoBehaviour
{

    private void OnEnable()
    {
        ScoreTrigger.OnScoreDetected += NetStretch;
    }
    private void OnDisable()
    {
        ScoreTrigger.OnScoreDetected -= NetStretch;
    }

    public void NetStretch()
    {
        StartCoroutine(StretchNet());
    }
    IEnumerator StretchNet()
    {
        transform.localScale = new Vector3(1, 1.1f, 1);
        yield return new WaitForSeconds(0.15f);
        transform.localScale = new Vector3(1,1,1);
    }
}
