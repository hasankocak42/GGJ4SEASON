using PlayerInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControls
{
    public class PlayerMoveKeyboard : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private Animator anim;
        [SerializeField] private FreeMovementMotor motor;
        [SerializeField] private Camera mainCamera;
        private Quaternion screenMovementSpace;
        private Vector3 screenMovementForward;
        private Vector3 screenMovementRight;

        private void Awake()
        {
            motor.movementDirection = Vector2.zero;
        }
        private void Start()
        {
            screenMovementSpace = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0);
            screenMovementForward = screenMovementSpace * Vector3.forward;
            screenMovementRight = screenMovementSpace * Vector3.right;
        }
        private void Update()
        {
            motor.movementDirection = _inputData.Horizontal * screenMovementRight +
           _inputData.Vertical * screenMovementForward;

            //if player moves anim run else dont
            if (_inputData.Horizontal != 0 || _inputData.Vertical != 0)
            {
                anim.SetBool(_inputData.ANIMATION_RUN, true);
            }
            else
            {
                anim.SetBool(_inputData.ANIMATION_RUN, false);
            }

            if (motor.movementDirection.sqrMagnitude > 1)
                motor.movementDirection.Normalize(); //To stabilize players velocity

        }

    }
}