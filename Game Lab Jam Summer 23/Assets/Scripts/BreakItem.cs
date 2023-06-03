using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakItem : MonoBehaviour
{
    [SerializeField] GameObject breakItem;

    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gameObject != null)
        {
            Debug.Log(breakItem.transform.childCount);
            
            for (int i = 0; i < breakItem.transform.childCount; i++)
            {
                //breakItem.transform.GetChild(i).transform.SetParent(null);
                //breakItem.transform.GetChild(i).GetComponent<FixedJoint>().connectedBody = null;
                breakItem.transform.GetChild(i).GetComponent<Rigidbody>().AddForce((Vector3.up * Random.Range(speed * 0.8f, speed) * Time.deltaTime));
            }

            breakItem.transform.DetachChildren();
            Destroy(breakItem);
        }
    }
}
