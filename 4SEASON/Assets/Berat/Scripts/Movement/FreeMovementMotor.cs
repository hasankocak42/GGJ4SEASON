using PlayerInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControls
{
    public class FreeMovementMotor : MonoBehaviour
    {
        [SerializeField] private PlayerMovementSettings playerSettings;
        [SerializeField] private Rigidbody myBody;

        [HideInInspector]
        public Vector3 movementDirection;

        Vector3 lookPos;
        private void Update()
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //if(Physics.Raycast(ray,out hit, 100)) {
            //     lookPos= hit.point;
            //}

            //Vector3 lookDir = lookPos - transform.position;
            //lookDir.y = 0;
            //transform.LookAt(transform.position + lookDir, Vector3.up);
            
        }
        private void FixedUpdate()
        {
            Vector3 targetVelocity = movementDirection * playerSettings.walkingSpeed;
            Vector3 deltaVelocity = targetVelocity - myBody.velocity;

            if (myBody.useGravity)
                deltaVelocity.y = 0f;
            myBody.AddForce(deltaVelocity * playerSettings.walkingSnapyness, ForceMode.Acceleration);



            Vector3 faceDir = movementDirection;

            if (faceDir == Vector3.zero)
            {
                myBody.angularVelocity = Vector3.zero;
            }
            else
            {

                //transform.forward local forward where player look the way .
                // Vector3.up 0,1,0 we are gonna change player's y rotation .
                float rotationAngle = AngleAroundAxis(transform.forward, faceDir, Vector3.up);
                myBody.angularVelocity = (Vector3.up * rotationAngle * playerSettings.turningSmoothing);
            }
        }
        float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
        {
            dirA = dirA - Vector3.Project(dirA, axis);
            dirB = dirB - Vector3.Project(dirB, axis);

            float angle = Vector3.Angle(dirA, dirB);

            return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
        }

    }
}