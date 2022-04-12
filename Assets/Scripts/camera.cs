using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float bottomY;
    [SerializeField] private float upperY;


    void Update ()
    {
        transform.position = new Vector3(transform.position.x,target.transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, bottomY, upperY), transform.position.z);
    }
}
