using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BrokenItem : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(speed * 0.8f, speed) * Time.deltaTime);

        //Transform parent = this.transform.parent;
        //this.transform.parent = null;
        //if (parent.childCount == 0)
        //{
            
        //    Destroy(parent.gameObject);
        //} 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
