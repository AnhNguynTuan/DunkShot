using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoops : MonoBehaviour
{
    public GameObject hoopPrefab;
    public void SpawnHoop()
    {
        Vector3 spawnPos = transform.position;
        GameObject newHoop = Instantiate(hoopPrefab, spawnPos, Quaternion.identity);
    }
}
