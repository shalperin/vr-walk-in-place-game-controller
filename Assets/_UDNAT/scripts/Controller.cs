using System;
using System.Threading;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


/// <summary>
/// Drive the XR Origin's Character Controller based on a walk in place input.
/// </summary>
namespace UDNAT
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private WalkSpeedProvider _walkSpeedProvider;
        [SerializeField] private WalkEngageProvider _walkEngageProvider;

        [Header("The XR Origin from the Unity VR template")]
        [SerializeField] private XROrigin _xrOrigin;

        private Camera mainCamera;
        private CharacterController characterController;

        [Header("Tuning")] 
        public float speed = 2.75f;
        
        private bool useCharacterController = true;

        private void Awake()
        {
            characterController = _xrOrigin.GetComponent<CharacterController>();
            mainCamera = _xrOrigin.GetComponentInChildren<Camera>();

            if (_xrOrigin == null)
            {
                throw new Exception("No XR Origin found on this GameObject");
            }

            if (characterController == null)
            {
                throw new Exception("No Character Controller found on XR Origin");
            }

            if (mainCamera == null)
            {
                throw new Exception("No Main Camera found on XR Origin");
            }

            if (_walkSpeedProvider == null)
            {
                throw new Exception("No WalkInputProvider assigned.");
            }

            if (_walkEngageProvider == null)
            {
                throw new Exception("No WalkEngageProvider assigned.");
            }

            if (characterController == null)
            {
                throw new Exception("No Character Controller assigned.");
            }
        }

        private void Update()
        {
            if (_walkEngageProvider.isWalking)
            {
                Move();
            }
        }


        private Vector3 MovementVector()
        {
            Vector3 forward = mainCamera.transform.forward;
            forward.y = 0;
            forward.Normalize();
            Vector3 movement = forward * speed * _walkSpeedProvider.stepSignal;
            return movement;
        }

        private void ApplyMovementToCharacterController(Vector3 movement)
        {
            characterController.Move(movement * Time.deltaTime);
        }

        private void ApplyMovementToXROrigin(Vector3 movement)
        {
            // terrain following currently breaks with this approach
            _xrOrigin.transform.position += movement * Time.deltaTime;
        }


        private void Move()
        {
            // Very tempted to refactor this whole thing 1st on the model of a Locomotion Provide
            // then actual _as_ a Locomotion Provider.
            var movement = MovementVector();
            if (useCharacterController)
            {
                ApplyMovementToCharacterController(movement);
            }
            else
            {
                ApplyMovementToXROrigin(movement);
            }
        }
    }
}