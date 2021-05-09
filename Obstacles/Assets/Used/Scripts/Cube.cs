using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float timer = 5;
    public GameObject destroyEffect;
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

