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
        [Header("Trigger/Click Input Action Reference (udnat folder)")]
        [SerializeField]
        private InputActionReference buttonAction;

        [SerializeField]
        [Header("Runtime state exposed publicly as IsWalking")]
        private bool _isWalking = true;

        public bool IsWalking
        {
            get => _isWalking;
            private set => _isWalking = value;
        }

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
            _isWalking = !_isWalking;
        }
    }
}