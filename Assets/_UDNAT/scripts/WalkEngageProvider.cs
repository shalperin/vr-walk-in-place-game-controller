using System;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Surface the isWalking boolean which toggles when walking is engaged or
/// disengaged based on the InputActionReference provided.
/// </summary>
namespace UDNAT
{
    public class WalkEngageProvider : MonoBehaviour
    {
        [field: Header("Output")]
        [field: SerializeField]
        public bool isWalking {get; private set;} = true;

        
        
        [Header("Input Action Reference (any button will work)")]
        [SerializeField]
        private InputActionReference buttonAction;
        
       

        private void OnEnable()
        {
            if (buttonAction != null)
            {
                buttonAction.action.performed += OnClick;
                buttonAction.action.Enable();
            }
        }

        private void OnDisable()
        {
            if (buttonAction != null)
            {
                buttonAction.action.performed -= OnClick;
                buttonAction.action.Disable();
            }
        }


        private void OnClick(InputAction.CallbackContext ctx)
        {
            Debug.Log("Clicked!");
            isWalking = !isWalking;
        }
    }
}