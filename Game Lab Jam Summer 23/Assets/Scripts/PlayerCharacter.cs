using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float grabDistance;
    [SerializeField] LayerMask grabLayerMask;
    [SerializeField] GameObject targetedObject;
    [SerializeField] GameObject currentRoom;

    //Left
    [SerializeField] Transform leftGrabTransform;
    [SerializeField] GameObject leftGrabGameObject;

    //Right
    [SerializeField] Transform rightGrabTransform;
    [SerializeField] GameObject rightGrabGameObject;

    Camera cam;
    Animator animator;

    private void Start()
    {
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
            }
        }
        else
        {
            if (targetedObject)
            {
                targetedObject.GetComponent<Outline>().enabled = false;
                targetedObject = null;
            }
        }

        if (playerController.GrabLeft())
        {
            if (leftGrabGameObject)
            {
                leftGrabGameObject.GetComponent<Rigidbody>().useGravity = true;
                leftGrabGameObject.GetComponent<Collider>().enabled = true;
                leftGrabGameObject = null;
            }

            if (targetedObject)
            {
                leftGrabGameObject = targetedObject;
                leftGrabGameObject.GetComponent<Rigidbody>().useGravity = false;
                leftGrabGameObject.GetComponent<Collider>().enabled = false;
                targetedObject.GetComponent<Outline>().enabled = false;
                targetedObject = null;
            }
        }

        if (playerController.GrabRight())
        {
            if (rightGrabGameObject)
            {
                rightGrabGameObject.GetComponent<Rigidbody>().useGravity = true;
                rightGrabGameObject.GetComponent<Collider>().enabled = true;
                rightGrabGameObject = null;
            }

            if (targetedObject)
            {
                rightGrabGameObject = targetedObject;
                rightGrabGameObject.GetComponent<Rigidbody>().useGravity = false;
                rightGrabGameObject.GetComponent<Collider>().enabled = false;
                targetedObject.GetComponent<Outline>().enabled = false;
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
            TrySmashObject(leftGrabGameObject);
        }

        if (rightGrabGameObject && !leftGrabGameObject && playerController.Smash())
        {
            animator.Play("LeftSmash");
            TrySmashObject(rightGrabGameObject);
        }

        Debug.DrawRay(cam.transform.position, cam.transform.forward * grabDistance, Color.red);
    }

    public void TryCombine(GameObject leftObject, GameObject rightObject)
    {
        Debug.Log("Trying to combine: " + leftObject.name + " with: " + rightGrabGameObject.name);

        currentRoom.transform.Find("Level Door").GetComponentInChildren<Animator>().Play("Open");
    }

    public void TrySmashObject(GameObject smashObject)
    {
        Debug.Log("Trying to smash: " + smashObject.name);
    }
}
