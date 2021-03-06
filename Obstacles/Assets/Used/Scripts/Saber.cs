using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class Saber : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerToHit;
    [SerializeField]
    private LayerMask layerToNotHit;
    [SerializeField] 
    //private int score = 1;
    private Vector3 previousPos;
    private bool hitsTarget;



    void Update()
    {
      
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layerToHit))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                DisplayScore.score++;
                Destroy(hit.transform.gameObject);
            }

        previousPos = transform.position;
        }   
    }
}
