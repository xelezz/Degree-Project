using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
public class ObjectSlice : MonoBehaviour
{
    public float cutInitVel = 100;
    [SerializeField]
    private Transform startCutPoint;
    [SerializeField]
    private Transform endCutPoint;
    [SerializeField]
    private LayerMask cuttingLayer;
    public VelocityEstimator velocityEstimator;
    public Material cutMaterial;
    public float timer = 2;

    void Update()
    {
        RaycastHit hit;
        Vector3 cutDir = endCutPoint.position - startCutPoint.position;
        bool hasHit = Physics.Raycast(startCutPoint.position, cutDir, out hit, cutDir.magnitude, cuttingLayer);
        if (hasHit)
        {
            Cut(hit.transform.gameObject, hit.point, velocityEstimator.GetVelocityEstimate());
        }
    }
    void Cut(GameObject target, Vector3 planePos, Vector3 cutVelocity)
    {
        Vector3 cutDir = endCutPoint.position - startCutPoint.position;
        Vector3 planeNorm = Vector3.Cross(cutVelocity, cutDir);
        SlicedHull cutTarget = target.Slice(planePos, planeNorm);

        if (cutTarget != null)
        {
            GameObject upperTarget = cutTarget.CreateUpperHull(target, cutMaterial);
            GameObject lowerTarget = cutTarget.CreateLowerHull(target, cutMaterial);

            CreateCutComponent(upperTarget);
            CreateCutComponent(lowerTarget);

            Destroy(target);
        }
        Debug.Log("You are cutting something");
    }
    void CreateCutComponent(GameObject targetToCut)
    {
        Rigidbody rb = targetToCut.AddComponent<Rigidbody>();
        MeshCollider col = targetToCut.AddComponent<MeshCollider>();
        col.convex = true;

        rb.AddExplosionForce(cutInitVel, targetToCut.transform.position, 1);
        Destroy(targetToCut, timer);
    }
}
