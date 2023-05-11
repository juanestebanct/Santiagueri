using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKSnapperr: MonoBehaviour
{
    [SerializeField][Range(0,1)] private float proceduralInfluence;
    [SerializeField] private MultiParentConstraint[] animatedBones;
    [SerializeField] private MultiParentConstraint[] proceduralBones;

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
        UpdateInfluence(proceduralInfluence);
    }
    
    private void OnValidate()
    {
        UpdateInfluence(proceduralInfluence);
    }
}
