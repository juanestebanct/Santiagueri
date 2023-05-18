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

    public SimpleMovement Player;
    public void Start()
    {
        timeChangeAnimation = CicleIdle;
    }
    public void setMotionValue(float value)
    {
        if (!Player.Dead)
        {
            GetComponent<Animator>().SetFloat("Speed", value);
            if (value <= 0.1)
            {
                timeChangeAnimation -= Time.deltaTime;
               // Debug.Log("idle" + timeChangeAnimation);
                if (timeChangeAnimation < 0)
                {

                    GetComponent<Animator>().SetTrigger("indie");

                    timeChangeAnimation = TimeIdle + CicleIdle;

                }

            }
            else
            {
                timeChangeAnimation = CicleIdle;
            }
        }
      
    }
    public void setAttactkTrigger()
    {
        if (!Player.Dead)
        {
            GetComponent<Animator>().SetTrigger("Atack");
            timeChangeAnimation = CicleIdle;
        }
            
    }
    public void SetDamageTrigger()
    {
        Debug.Log("se invoco el evetno desde animator ");
        GetComponent<Animator>().SetTrigger("Damage");

    }
    public void Jump_Animate()
    {
        if (!Player.Dead)
        {
            GetComponent<Animator>().SetTrigger("Jump");
            timeChangeAnimation = CicleIdle;
        }
    }

    public void Dead()
    {
        GetComponent<Animator>().SetTrigger("Dead");
    }
}
