using grupo;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace grupo
{
    [Serializable]
    public class UntyFloatEvent: UnityEvent<float> { }
}
public class SimpleMovement : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector2 inputValue;
    [SerializeField] private Vector2 smoothInput;
    [SerializeField] private float speed;
    [SerializeField] private float Accelelation;
    [SerializeField] private UntyFloatEvent OnMoves;
    public void Move(CallbackContext contex)
    {
        inputValue = contex.ReadValue<Vector2>();
       
       
    }
    private void Update()
    {
        smoothInput = Vector2.Lerp(smoothInput,inputValue,Time.deltaTime* Accelelation);
        Vector3 forwardVector = Vector3.ProjectOnPlane(cameraTransform.forward, transform.up);
        Vector3 rightVector = cameraTransform.right;
        Vector3 motionVector = (forwardVector * smoothInput.y + rightVector * smoothInput.x)*speed*1f;
        transform.Translate(motionVector *Time.deltaTime, Space.World);
        OnMoves?.Invoke(smoothInput.magnitude);
        if (motionVector.magnitude > 0.01)
        {
            transform.forward = motionVector;
        }
    }

}
