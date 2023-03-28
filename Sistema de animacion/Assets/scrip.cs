using UnityEngine;
using UnityEngine.InputSystem;
using CallBackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class scrip : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    public void Move(InputAction.CallbackContext context)
    {
      
        Vector2 motionValue = context.ReadValue<Vector2>();
        Vector3 forwardVector = Vector3.ProjectOnPlane(cameraTransform.forward,transform.up);
        Vector3 rightVector = cameraTransform.right;
        transform.Translate(forwardVector * motionValue.y + rightVector * motionValue.x);
    }
}
