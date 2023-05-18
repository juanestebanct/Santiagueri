using grupo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    [SerializeField] private float Forcejump;
    [SerializeField] private int Live;
    private bool CanResiveDamege=true;

     public UnityEvent OnJump;
     public UnityEvent OnHit;
     public UnityEvent DeadEvent;
     public bool Dead;
   

     

    public Rigidbody rb;
    public void Move(CallbackContext contex)
    {
        inputValue = contex.ReadValue<Vector2>();
        rb= GetComponent<Rigidbody>();
      
    }

    public void OnDamge()
    {
        if (CanResiveDamege && !Dead)
        {
            Live--;
            Debug.Log("se invoco el evetno desde simpleMovement ");
            OnHit.Invoke();
            CanResiveDamege = false;
            StartCoroutine(TimeDead());
            if (Live<=0)
            {
                Dead = true;
                DeadEvent.Invoke();
                Debug.Log("Muerto ");
            }
        }
       
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded() && !Dead)
        {
            Debug.Log("salto");
            rb.AddForce(Vector3.up * Forcejump, ForceMode.VelocityChange);
            if (context.action.WasPerformedThisFrame())
            {
                OnJump.Invoke();
            }
        }
        else
        {
            Debug.Log("no puede saltar");
        }
    
    }
    private void Update()
    {
        if (!Dead)
        {
            smoothInput = Vector2.Lerp(smoothInput, inputValue, Time.deltaTime * Accelelation);
            Vector3 forwardVector = Vector3.ProjectOnPlane(cameraTransform.forward, transform.up);
            Vector3 rightVector = cameraTransform.right;
            Vector3 motionVector = (forwardVector * smoothInput.y + rightVector * smoothInput.x) * speed * 1f;
            transform.Translate(motionVector * Time.deltaTime, Space.World);
            OnMoves?.Invoke(smoothInput
                .magnitude);
            if (motionVector.magnitude > 0.01)
            {
                transform.forward = motionVector;
            }
        }
    
    }
    private bool IsGrounded()
    {
        Debug.Log("toca el suelo");
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }
    IEnumerator TimeDead()
    {
        yield return new WaitForSeconds(1f);
        CanResiveDamege = true;
    }
}
