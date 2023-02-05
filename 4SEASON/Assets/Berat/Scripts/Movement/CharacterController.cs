using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody myBody;
    Vector3 lookPos;
    public float speed = 5;
    public Camera cam;
    private void Update()
    {
        lookPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        myBody.MovePosition(myBody.position + movement * speed * Time.fixedDeltaTime);

        Vector3 lookDir = lookPos - myBody.position;

    }
    }
