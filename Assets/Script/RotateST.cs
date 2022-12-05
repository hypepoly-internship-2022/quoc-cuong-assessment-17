using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateST : MonoBehaviour
{

    [SerializeField] private Vector3 rotation;
    [SerializeField] private int speed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
