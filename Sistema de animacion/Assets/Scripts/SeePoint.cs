using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SeePoint : MonoBehaviour
{
    private const float REFRESH_DELAY = 0.5f;

    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask detectionMask;
    [SerializeField] private Transform referencePoint;
    [SerializeField] private Transform raycastReference;

    [SerializeField] private MultiAimConstraint[] multiAimConstraints;
    //Encontrar objetos idoneos
    public bool IsCollicion;
    /// <summary>
    /// Returns all suitable objects for IK Snap
    /// </summary>
    /// 
    private Collider[] Query()
    {
        return Physics.OverlapSphere(referencePoint.position, detectionRadius, detectionMask);
    }

    //Encontrar punto de referencia más cercano
    private bool GetNearestPositionForSnap(Collider[] nearColliders, out Vector3 nearestPoint)
    {
        try
        {
            //Encontrar punto mas cercano de la superficie

            //Se crea una lista de los puntos más cercanos a los colliders
            var closestPoints = nearColliders.Select(collider => collider.ClosestPoint(referencePoint.position));

            //Se encuentra el punto más cercano, del collider más cercano
            Vector3 closestPoint = closestPoints.OrderBy(position => Vector3.Distance(referencePoint.position, position))
                .First();

            //Evaluar si el punto de referencia está dentro del collider
            if (closestPoint == referencePoint.position)
            {
                //Estoy dentro
                //Toca castear el rayo de la mano al punto de referencia
                Ray ray = new Ray(raycastReference.position, referencePoint.position - raycastReference.position);
                if (Physics.Raycast(ray, out RaycastHit hit, ray.direction.magnitude, detectionMask))
                {
                    //Devolver punto de interseccion
                    nearestPoint = hit.point;
                    return true;
                }
            }
            else
            {
                //Estoy fuera
                nearestPoint = closestPoint;
                return true;
            }

        }
        catch (Exception e)
        {
            //ignore
        }
        //Si no se detecta nada, se retorna la misma mano
        nearestPoint = transform.position;
        return false;
    }

    void Update()
    {
        if (!IsCollicion)
        {
            foreach (var bone in multiAimConstraints)
            {
                bone.weight = 0f;
            }
        }
        else
        {
            foreach (var bone in multiAimConstraints)
            {
                bone.weight = 1f;
            }
        }
    }
    private void LateUpdate()
    {
        if (GetNearestPositionForSnap(Query(), out Vector3 nearestPosition))
        {
            //Superficie con posición valida cerca
            transform.position = nearestPosition;
            //Mandar la señal
            Debug.Log("collider");
            IsCollicion = true;
        }
        else
        {
            gameObject.SendMessage("OverrideIK", false, SendMessageOptions.DontRequireReceiver);
            Debug.Log("on collider");
            IsCollicion = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(referencePoint.position, detectionRadius);
    }
}
