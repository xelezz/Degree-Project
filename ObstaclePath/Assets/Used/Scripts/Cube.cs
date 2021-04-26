using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float timer = 5;
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;
        if (true)
        {

        }
    }
}
