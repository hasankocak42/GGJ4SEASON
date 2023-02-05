using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControls
{
    [CreateAssetMenu(menuName = "Player/Movement Settings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        public float walkingSpeed = 5f;
        public float walkingSnapyness = 50f;
        public float turningSmoothing = 0.3f;

    }
}