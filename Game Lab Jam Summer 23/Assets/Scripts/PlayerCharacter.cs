using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    PlayerController playerController;

    [Header("Variable Values")]
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float grabDistance;
    [SerializeField] LayerMask grabLayerMask;
    GameObject targetedObject;
    GameObject currentRoom;

    [Header("Effects")]
    [SerializeField] GameObject combineEffect;
    [SerializeField] AudioClip successSound;

    //Left
    [Header("Left Hand")]
    [SerializeField] Transform leftGrabTransform;
    [SerializeField] GameObject leftGrabGameObject;

    //Right
    [Header("Right Hand")]
    [SerializeField] Transform rightGrabTransform;
    [SerializeField] GameObject rightGrabGameObject;

    Camera cam;
    Animator animator;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        Cursor.visible = false;
        currentRoom = GameObject.Find("Room_1");
        animator = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction = playerController.GetMovementVector().x * transform.right + playerController.GetMovementVector().y * transform.forward;

        if (playerController.GetMovementVector() != Vector2.zero)
        {
            transform.position += direction * movementSpeed * Time.deltaTime;
        }
        transform.Rotate(new Vector3(0, playerController.CameraMovement().x * rotationSpeed, 0));

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, grabDistance, grabLayerMask))
        {
            if (hit.transform.gameObject != leftGrabGameObject || hit.transform.gameObject != rightGrabGameObject)
            {
                targetedObject = hit.transform.gameObject;
                targetedObject.GetComponent<Outline>().enabled = true;

                if (targetedObject.GetComponent<FixedJoint>())
                {
                    targetedObject.GetComponent<FixedJoint>().connectedBody.GetComponent<Outline>().enabled = true;
                }
            }
        }
        else
        {
            if (targetedObject)
            {
                targetedObject.GetComponent<Outline>().enabled = false;

                if (targetedObject.GetComponent<FixedJoint>())
                {
                    targetedObject.GetComponent<FixedJoint>().connectedBody.GetComponent<Outline>().enabled = false;
                }

                targetedObject = null;
            }
        }

        if (playerController.GrabLeft())
        {
            if (leftGrabGameObject)
            {
                ActivateObject(leftGrabGameObject);
                leftGrabGameObject = null;
            }

            if (targetedObject)
            {
                if (rightGrabGameObject && targetedObject.GetComponent<FixedJoint>())
                    if (targetedObject.GetComponent<FixedJoint>().connectedBody.name == rightGrabGameObject.name)
                        return;

                leftGrabGameObject = targetedObject;
                DeactivateObject(leftGrabGameObject);
                targetedObject = null;
            }
        }

        if (playerController.GrabRight())
        {
            if (rightGrabGameObject)
            {
                ActivateObject(rightGrabGameObject);
                rightGrabGameObject = null;
            }

            if (targetedObject)
            {
                if (leftGrabGameObject && targetedObject.GetComponent<FixedJoint>())
                    if (targetedObject.GetComponent<FixedJoint>().connectedBody.name == leftGrabGameObject.name)
                        return;

                rightGrabGameObject = targetedObject;
                DeactivateObject(rightGrabGameObject);
                targetedObject = null;
            }
        }

        if (leftGrabGameObject)
        {
            leftGrabGameObject.transform.position = leftGrabTransform.position;
        }

        if (rightGrabGameObject)
        {
            rightGrabGameObject.transform.position = rightGrabTransform.position;
        }

        if (rightGrabGameObject && leftGrabGameObject && playerController.Combine())
        {
            TryCombine(leftGrabGameObject, rightGrabGameObject);
        }

        if (leftGrabGameObject && !rightGrabGameObject && playerController.Smash())
        {
            animator.Play("RightSmash");
            //if (TrySmashObject(leftGrabGameObject))
            //{
            //    leftGrabGameObject = null;
            //}
        }

        if (rightGrabGameObject && !leftGrabGameObject && playerController.Smash())
        {
            animator.Play("LeftSmash");
            //if (TrySmashObject(rightGrabGameObject))
            //{
            //    rightGrabGameObject = null;
            //}
        }

        Debug.DrawRay(cam.transform.position, cam.transform.forward * grabDistance, Color.red);
    }

    public void TryCombine(GameObject leftObject, GameObject rightObject)
    {
        if (!leftObject.GetComponent<ItemComponent>().isItemAccepted(rightObject))
        {
            return;
        }

        if (!leftObject.transform.Find("AttachmentPoint") || !rightObject.transform.Find("AttachmentPoint"))
        {
            return;
        }

        animator.Play("Combine");

        //currentRoom.transform.Find("Level Door").GetComponentInChildren<Animator>().Play("Open");
    }

    public void CombineObjects()
    {
        Instantiate(combineEffect, leftGrabTransform.position, Quaternion.Euler(-90, 0, 0));
        GetComponent<CombineItem>().JoinItem(leftGrabGameObject, rightGrabGameObject);
        GetComponent<AudioSource>().PlayOneShot(successSound);

        leftGrabGameObject = null;
        rightGrabGameObject = null;
        targetedObject = null;
    }

    public bool TrySmashObject(GameObject smashObject)
    {
        Debug.Log("Trying to smash: " + smashObject.name);

        if (smashObject.GetComponent<FixedJoint>())
        {
            GameObject otherObject = smashObject.GetComponent<FixedJoint>().connectedBody.gameObject;

            smashObject.GetComponent<ItemComponent>().UnbindItem(otherObject, true);

            ActivateObject(smashObject);
            ActivateObject(otherObject);

            Destroy(otherObject.GetComponent<FixedJoint>());
            Destroy(smashObject.GetComponent<FixedJoint>());

            Destroy(GameObject.Find(smashObject.name + " + " + otherObject.name));
            Destroy(GameObject.Find(otherObject.name + " + " + smashObject.name));

            return true;
        }

        return false;
    }

    public void ActivateObject(GameObject go)
    {
        go.GetComponent<Rigidbody>().useGravity = true;
        go.GetComponent<Collider>().enabled = true;
        go.transform.SetParent(null);

        if (go.GetComponent<FixedJoint>())
        {
            go.GetComponent<FixedJoint>().connectedBody.GetComponent<Rigidbody>().useGravity = true;
            go.GetComponent<FixedJoint>().connectedBody.GetComponent<Collider>().enabled = true;
        }
    }

    public void DeactivateObject(GameObject go)
    {
        go.GetComponent<Rigidbody>().useGravity = false;
        go.GetComponent<Collider>().enabled = false;
        go.GetComponent<Outline>().enabled = false;

        if (go.GetComponent<FixedJoint>())
        {
            go.GetComponent<FixedJoint>().connectedBody.GetComponent<Rigidbody>().useGravity = false;
            go.GetComponent<FixedJoint>().connectedBody.GetComponent<Collider>().enabled = false;
            go.GetComponent<FixedJoint>().connectedBody.GetComponent<Outline>().enabled = false;
        }
    }

    public List<GameObject> GetHeldItems()
    {
        List<GameObject> tempList = new List<GameObject>();
        if (leftGrabGameObject)
            tempList.Add(leftGrabGameObject);
        if (rightGrabGameObject)
            tempList.Add(rightGrabGameObject);

        return tempList;
    }

    public GameObject GetLeftItem()
    {
        return leftGrabGameObject;
    }

    public GameObject GetRightObject()
    {
        return rightGrabGameObject;
    }

    public void DisarmRight()
    {
        if (TrySmashObject(rightGrabGameObject))
        {
            rightGrabGameObject = null;
        }
    }

    public void DisarmLeft()
    {
        if (TrySmashObject(leftGrabGameObject))
        {
            leftGrabGameObject = null;
        }
    }
}
