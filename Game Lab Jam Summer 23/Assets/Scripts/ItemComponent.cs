using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField] List<Transform> attachmentPoints = new List<Transform>();
    [SerializeField] ItemComponent[] attachedItems;
    [SerializeField] List<string> acceptableItems = new List<string>();
    [SerializeField] bool isShootable;

    void Start()
    {
        attachedItems = new ItemComponent[attachmentPoints.Count];
    }

    public void BindItem(GameObject go, bool first)
    {
        if (Full() || go.GetComponent<ItemComponent>().Full() && first || !isItemAccepted(go))
            return;

        for (int i = 0; i < attachmentPoints.Count; i++)
        {
            if (attachedItems[i] == null)
            {
                attachedItems[i] = go.GetComponent<ItemComponent>();

                if (first)
                {
                    go.GetComponent<ItemComponent>().BindItem(gameObject, false);
                    Vector3 tempVector = attachmentPoints[i].position - attachedItems[i].GetAttachPointByObject(gameObject).transform.position;
                }

                go.transform.position = attachmentPoints[i].transform.position;
                go.transform.rotation = gameObject.transform.rotation;


                return;
            }
        }
    }

    public void UnbindItem(GameObject go, bool first)
    {
        for (int i = 0; i < attachedItems.Length; i++)
        {
            if (attachedItems[i] == null)
                continue;

            if (attachedItems[i].name == go.name)
            {
                if (first)
                    attachedItems[i].UnbindItem(gameObject, false);
                attachedItems[i] = null;
                return;
            }
        }
    }

    public ItemComponent[] GetAttachedItems()
    {
        return attachedItems;
    }

    public GameObject GetAttachPointByObject(GameObject go)
    {
        for (int i = 0; i < attachmentPoints.Count; i++)
        {
            if (attachedItems[i].name == go.name)
                return attachmentPoints[i].gameObject;
        }

        return null;
    }

    public GameObject GetNextAvailableAttachPoint()
    {
        for(int i = 0; i < attachmentPoints.Count; i++)
        {
            if (attachedItems[i] == null)
                return attachmentPoints[i].gameObject;
        }

        return null;
    }

    public bool Full()
    {
        for (int i = 0; i < attachedItems.Length; i++)
        {
            if (attachedItems[i] == null)
                return false;
        }

        return true;
    }

    public bool isItemAccepted(GameObject go)
    {
        foreach (string name in acceptableItems)
        {
            if (go.name == name)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsConnected()
    {
        int numberOfItems = 0;

        foreach(ItemComponent item in attachedItems)
        {
            if (item != null)
                numberOfItems++;
        }

        return numberOfItems > 0;
    }
    public void Shoot(GameObject go)
    {
        Debug.Log(gameObject.name + " shot " + go.name + "!");

        //Vector3 directionVector = (go.transform.position - gameObject.transform.position).normalized;
        Vector3 directionVector = (Camera.main.gameObject.transform.forward);
        go.GetComponent<Rigidbody>().AddForceAtPosition(directionVector * 1000f, gameObject.transform.position/*-new Vector3(0,0.2f,0)*/);

    }
}
