using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Watches for a button click (currently left-controller trigger) and
/// toggles a signal that is used by the <see cref="Controller"/> to determine whether
/// the user is walking or not.
/// </summary>
public class WalkEngageProvider : MonoBehaviour
{
    [Header("Trigger/Click Input Action Reference (udnat folder)")]
    public InputActionReference buttonAction;

    public bool isWalking;
    
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

