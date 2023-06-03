using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineItem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject JoinItem(GameObject gameObjectOne, GameObject gameObjectTwo)
    {

        GameObject newObject = new GameObject();

        newObject.name = gameObjectOne.name + " + " + gameObjectTwo.name;

        gameObjectTwo.transform.position = gameObjectOne.transform.GetChild(0).position;
        gameObjectTwo.transform.rotation = gameObjectOne.transform.rotation;

        Vector3 tempVector = gameObjectOne.transform.GetChild(0).position - gameObjectTwo.transform.GetChild(0).position;

        gameObjectTwo.transform.position += tempVector;

        gameObjectOne.transform.parent = newObject.transform;
        gameObjectTwo.transform.parent = newObject.transform;

        gameObjectOne.GetComponent<Collider>().enabled = true;
        gameObjectTwo.GetComponent<Collider>().enabled = true;

        gameObjectOne.GetComponent<Rigidbody>().useGravity = true;
        //gameObjectTwo.GetComponent<Rigidbody>().useGravity = true;

        gameObjectOne.AddComponent<FixedJoint>().connectedBody = gameObjectTwo.GetComponent<Rigidbody>();
        gameObjectTwo.AddComponent<FixedJoint>().connectedBody = gameObjectOne.GetComponent<Rigidbody>();


        
        return newObject;
    }
}
