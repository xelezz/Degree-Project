using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class Saber : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;
    [SerializeField] 
    private int score = 1;
    private Vector3 previousPos;



    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                
                Destroy(hit.transform.gameObject);
                score = score += 1;
            }
            else
            {
                score = score -= 1;
            }
            if (score <= 0)
            {
               // SceneManager.LoadScene("LoseScene");
                Debug.Log("You loose");
            }
        }
        previousPos = transform.position;
    }
}
