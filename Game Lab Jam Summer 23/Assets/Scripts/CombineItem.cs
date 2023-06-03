using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineItem : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectOne;
    [SerializeField] private GameObject gameObjectTwo;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JoinItem()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameObjectOne != null && gameObjectTwo != null)
        {
            GameObject newObject = new GameObject();

            //gameObjectOne.GetComponent<MeshCollider>().enabled= false;
            //gameObjectTwo.GetComponent<MeshCollider>().enabled = false;


            gameObjectTwo.transform.position = gameObjectOne.transform.GetChild(0).position;
            gameObjectTwo.transform.rotation = gameObjectOne.transform.rotation;

            Vector3 tempVector = gameObjectOne.transform.GetChild(0).position - gameObjectTwo.transform.GetChild(0).position;

            gameObjectTwo.transform.position += tempVector;

            gameObjectOne.transform.parent = newObject.transform;
            gameObjectTwo.transform.parent = newObject.transform;

            gameObjectOne.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObjectTwo.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //gameObjectOne.GetComponent<FixedJoint>().connectedBody = gameObjectTwo.GetComponent<Rigidbody>();

            //gameObjectOne.GetComponent<Rigidbody>().isKinematic = true;
            //gameObjectTwo.GetComponent<Rigidbody>().isKinematic = true;

            //newObject.AddComponent<Rigidbody>();    

            //gameObjectOne.GetComponent<MeshCollider>().enabled = true;
            //gameObjectTwo.GetComponent<MeshCollider>().enabled = true;
        }
    }
}
