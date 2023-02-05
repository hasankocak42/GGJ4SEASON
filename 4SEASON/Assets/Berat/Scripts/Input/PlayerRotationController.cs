using PlayerInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControls
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField] private InputData rotationInput;
        [SerializeField] private Transform playerTransform;


        private void Update()
        {
            playerTransform.Rotate(0, rotationInput.Horizontal, 0, Space.Self);
        }
    }
}