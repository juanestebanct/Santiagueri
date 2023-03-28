using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkSurface : MonoBehaviour
{
    // Start is called before the first frame update
    private const float refresh_Delay = 0.5f;
    [SerializeField] private float detecionRadius;
    void Query()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,detecionRadius);
    }
}
