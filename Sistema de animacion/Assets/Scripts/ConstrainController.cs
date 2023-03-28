using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ConstrainController : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] float proceduralInfluence;
    [SerializeField] MultiParentConstraint[] animateBones;
    [SerializeField] MultiParentConstraint[] proceduralBones;

    private void UpdateInfuelnce(float weight)
    {
        if (animateBones == null) return;

        foreach (MultiParentConstraint multiParentConstraint in animateBones)
        {
            if (multiParentConstraint == null) continue;
            multiParentConstraint.weight = weight;
        }

        if (proceduralBones == null) return;
        
        foreach (MultiParentConstraint proceduralCOntraint in proceduralBones)
        {
            if(proceduralCOntraint == null) continue;
            proceduralCOntraint.weight = 1 - weight;
        }
    }
    private void OnValidate()
    {
        UpdateInfuelnce(proceduralInfluence);
    }
}
