using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ConstraintController : MonoBehaviour
{
    [SerializeField][Range(0,1)] private float proceduralInfluence;
    [SerializeField] private MultiParentConstraint[] animatedBones;

    private void UpdateInfluence(float weight)
    {
        if (animatedBones == null) return;
        
        foreach (MultiParentConstraint multiParentConstraint in animatedBones)
        {
            if (multiParentConstraint == null) continue;
            multiParentConstraint.weight = weight;
        }
    }
    
    private void OnValidate()
    {
        UpdateInfluence(proceduralInfluence);
    }
}
