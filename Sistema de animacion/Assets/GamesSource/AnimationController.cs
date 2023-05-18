using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public float timeChangeAnimation;
    public float CicleIdle;
    public bool idle;
    public int TimeIdle;
    public void Start()
    {
        timeChangeAnimation = CicleIdle;
    }
    public void setMotionValue(float value)
    {
        GetComponent<Animator>().SetFloat("Speed",value);
        if (value <= 0.1)
        {
            timeChangeAnimation-= Time.deltaTime;
            Debug.Log("idle"+ timeChangeAnimation);
            if (timeChangeAnimation < 0 )
            {
          
                GetComponent<Animator>().SetTrigger("indie");
                 
                timeChangeAnimation = TimeIdle+ CicleIdle;
                      
            }

        }
        else
        {
            timeChangeAnimation = CicleIdle;
        }
    }
    public void setAttactkTrigger()
    {
        GetComponent<Animator>().SetTrigger("Atack");
        timeChangeAnimation = CicleIdle;
    }
    public void SetDamageTrigger()
    {

    }
    public void Jump_Animate()
    {
        GetComponent<Animator>().SetTrigger("Jump");
        timeChangeAnimation = CicleIdle;
    }
}
