using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputData[] _inputDataArray;
        [SerializeField] private InputData _rotationInputData;
       

        private Vector3 _lastMouseInput;
        
        private void Update()
        {
            for (int i = 0; i < _inputDataArray.Length; i++)
            {
                _inputDataArray[i].ProcessInput();
            }

            


            _rotationInputData.Horizontal = (Input.mousePosition.x - _lastMouseInput.x);
            _lastMouseInput = Input.mousePosition;



        }

    }
}
