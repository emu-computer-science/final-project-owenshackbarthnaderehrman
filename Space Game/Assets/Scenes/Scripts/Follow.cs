using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    void LateUpdate()
    {
        Vector3 dest = transform.position;
        Vector3 pos = GameObject.Find("Player").transform.position;
        dest.x = pos.x;
        dest.y = pos.y;
        transform.position = dest;
    }
}
