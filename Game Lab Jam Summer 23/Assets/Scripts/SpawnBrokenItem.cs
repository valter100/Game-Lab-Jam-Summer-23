using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBrokenItem : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < spawnObject.transform.childCount; i++)
            {
                Instantiate(spawnObject.transform.GetChild(i), this.transform.position, this.transform.rotation);
            }
            
            Destroy(this.gameObject);
        }
    }
}
