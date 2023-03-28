using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ContrainController : MonoBehaviour
{

    [SerializeField] [Range(0, 1)] private float produraLinfluence;
    [SerializeField]private MultiParentConstraint[] animatedBones;
    [SerializeField] private MultiParentConstraint[] proceduralBones;
    // Start is called before the first frame update
    private void UpdateInfluence(float weigth)
    {
        if (animatedBones == null) return;
        foreach ( MultiParentConstraint multiparent in animatedBones)
        {
            if (animatedBones == null) continue;
            multiparent.weight =weigth;
        }
        if (proceduralBones==null) return;
        foreach (MultiParentConstraint proceduralConstrint in proceduralBones)
        {
            if (proceduralConstrint == null) continue;
            {
                proceduralConstrint.weight = weigth - 1;
            }
        }
    }
    private void OnValidate()
    {
        UpdateInfluence(produraLinfluence);
    }
}
