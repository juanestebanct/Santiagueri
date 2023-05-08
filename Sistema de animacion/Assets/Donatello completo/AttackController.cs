using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    [SerializeField]public UnityEvent onAttack;
    [SerializeField]public UnityEvent onDamage;
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            Debug.Log("a");
            onAttack?.Invoke();
        }
       
    }
    public void GetHit()
    {
        Debug.Log("lo dañaron");
        onDamage?.Invoke();
    }
}
