using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreTrigger : MonoBehaviour
{
    public static event Action OnScoreDetected;
    public GameObject hoopPrefab;
    public bool isActive;
    private void Awake()
    {
        isActive = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            OnScoreDetected?.Invoke();
            collision.gameObject.GetComponent<Ball>().SetState(BallState.Landing);
            if(isActive)
            {
                Debug.Log("Cong diem");
                GameManager.Instance.AddScore();
                Debug.Log("Thay vanh ro");
                isActive = false;
            }
        }
    }
    public void SpawnHoop()
    {
        Vector3 spawnPos = transform.position;
        GameObject newHoop = Instantiate(hoopPrefab, spawnPos, Quaternion.identity);
    }
}
