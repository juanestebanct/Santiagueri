using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{

    public void setMotionValue(float value)
    {
        GetComponent<Animator>().SetFloat("Speed",value);
    }
    public void setAttactkTrigger()
    {
        GetComponent<Animator>().SetTrigger("Atack");
    }
    public void SetDamageTrigger()
    {

    }
}
