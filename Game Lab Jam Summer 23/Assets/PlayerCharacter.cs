using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float grabDistance;
    [SerializeField] Transform grabTransform;
    [SerializeField] LayerMask grabLayerMask;
    [SerializeField] GameObject grabGameObject;
    Camera cam;
    Animator animator;

    private void Start()
    {
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

        if (playerController.Smash())
        {
            animator.Play("Punch");
        }

        if (playerController.Grab())
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, grabDistance, grabLayerMask))
            {
                hit.transform.position = grabTransform.position;
            }
        }

        Debug.DrawRay(cam.transform.position, cam.transform.forward * grabDistance, Color.red);
    }
}
