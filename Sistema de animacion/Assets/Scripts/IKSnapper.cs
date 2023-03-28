using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKSnapper : MonoBehaviour
{
    private float proceduralInfluence;
    [SerializeField] private MultiParentConstraint[] animatedBones;
    [SerializeField] private MultiParentConstraint[] proceduralBones;
    [SerializeField] private AnimationCurve activationAnimation;
    [SerializeField] private AnimationCurve deactivationAnimation;
    private bool currentOverride;
    
    private void UpdateInfluence(float weight)
    {
        if (animatedBones == null) return;
        
        foreach (MultiParentConstraint multiParentConstraint in animatedBones)
        {
            if (multiParentConstraint == null) continue;
            multiParentConstraint.weight = weight;
        }

        if (proceduralBones == null) return;
        
        foreach (MultiParentConstraint proceduralConstraint in proceduralBones)
        {
            if (proceduralConstraint == null) continue;
            proceduralConstraint.weight = 1 - weight;
        }
    }

    public void OverrideIK(bool state)
    {
        proceduralInfluence = state ? 1 : 0;
        if (state != currentOverride)
        {
            currentOverride = state;
            StartCoroutine(AnimateInfluence());
        }
    }

    IEnumerator AnimateInfluence()
    {
        AnimationCurve curve = currentOverride? activationAnimation: deactivationAnimation;
        //Actualiza la influencia poco a poco, hasta llegar a los puntos limite
        for (float time = 0; time < 1f; time += Time.deltaTime)
        {
            proceduralInfluence = curve.Evaluate(time);
            yield return null;
        }
    }
}