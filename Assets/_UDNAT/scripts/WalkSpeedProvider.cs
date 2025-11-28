using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Surface a walking "signal" that changes proportionally to how
/// fast the user is walking in place.  The current algorithm uses
/// controller vertical velocity with damping configurable via the
/// inspector.
/// </summary>
namespace UDNAT
{
    public class WalkSpeedProvider : MonoBehaviour
    {
        [Header("Inputs")] 
        [SerializeField] private  InputActionReference headPosition;
        [SerializeField] private  InputActionReference leftControllerPosition;
        [SerializeField] private  InputActionReference rightControllerPosition;

        [Header("Runtime state exposed publicly as StepSignal")]
        [SerializeField] private float _stepSignal;
        public float StepSignal
        {
            get => _stepSignal;
            private set => _stepSignal = value;
        }
    

        [Header("Tuning")] public float sensitivity = 1.5f;
        public float damping = 5f;

        private float lastPositionL;
        private float lastPositionR;

        private float verticalVelocityL;
        private float verticalVelocityR;
        private float averageVerticalVelocity;

        public enum controllerCombinationMethodTypes
        {
            average,
            max,
            sum,
            min
        }

        public controllerCombinationMethodTypes controllerCombinationMethod =
            controllerCombinationMethodTypes.average;


        public enum tStyleTypes
        {
            linearEulerStep, // forward euler integration coefficient
            exactExponentialDecayCoefficient
        }

        public tStyleTypes tStyle = tStyleTypes.exactExponentialDecayCoefficient;

        void Start()
        {
            /*
             * If you are ever teaching input actions to someone make the point that what I am doing
             * with the leftController / rightController (GameObjects) transforms here, is functionally equivalent to what I am doing
             * through the left and right Position actions below.
             *
             * lastPositionL = leftController.transform.position.y - xrOrigin.transform.position.y;
             * lastPositionR = rightController.transform.position.y - xrOrigin.transform.position.y;
             */
            var headPosY = headPosition.action.ReadValue<Vector3>().y;
            lastPositionL = leftControllerPosition.action.ReadValue<Vector3>().y - headPosY;
            lastPositionR = rightControllerPosition.action.ReadValue<Vector3>().y - headPosY;

        }

        void Update()
        {
            // Estimate vertical velocity (Y-axis)
            var headPosY = headPosition.action.ReadValue<Vector3>().y;

            var currentPosL = leftControllerPosition.action.ReadValue<Vector3>().y - headPosY;
            var dyL = currentPosL - lastPositionL;
            verticalVelocityL = dyL / Time.deltaTime;
            lastPositionL = currentPosL;
            var rawL = Mathf.Abs(verticalVelocityL) * sensitivity;

            var currentPosR = rightControllerPosition.action.ReadValue<Vector3>().y - headPosY;
            var dyR = currentPosR - lastPositionR;
            verticalVelocityR = dyR / Time.deltaTime;
            lastPositionR = currentPosR;
            var rawR = Mathf.Abs(verticalVelocityR) * sensitivity;

            float rawCombined;
            switch (controllerCombinationMethod)
            {
                case controllerCombinationMethodTypes.average:
                    rawCombined = (rawL + rawR) / 2;
                    break;
                case controllerCombinationMethodTypes.max:
                    rawCombined = Mathf.Max(rawL, rawR);
                    break;
                case controllerCombinationMethodTypes.sum:
                    rawCombined = rawL + rawR;
                    break;
                case controllerCombinationMethodTypes.min:
                    rawCombined = Mathf.Min(rawL, rawR);
                    break;
                default:
                    rawCombined = Mathf.Max(rawL, rawR);
                    break;
            }


            // Smooth signal
            float t;
            switch (tStyle)
            {
                case tStyleTypes.linearEulerStep:
                    t = Time.deltaTime * damping;
                    break;
                case tStyleTypes.exactExponentialDecayCoefficient:
                    t = 1f - Mathf.Exp(-damping * Time.deltaTime);
                    break;
                default:
                    t = 1f - Mathf.Exp(-damping * Time.deltaTime);
                    break;
            }

            _stepSignal = Mathf.Lerp(_stepSignal, rawCombined, t);
        }


        private void OnEnable()
        {
            if (leftControllerPosition != null && rightControllerPosition != null)
            {
                leftControllerPosition.action.Enable();
                rightControllerPosition.action.Enable();
            }
            else
            {
                throw new System.Exception("[onEnable] Left position input action references not assigned.");
            }
        }

        private void OnDisable()
        {
            if (leftControllerPosition != null && rightControllerPosition != null)
            {
                leftControllerPosition.action.Disable();
                rightControllerPosition.action.Disable();
            }
            else
            {
                throw new System.Exception("[onDisable] Left position input action references not assigned.");
            }
        }
    }
}