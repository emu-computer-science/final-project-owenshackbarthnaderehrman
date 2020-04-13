using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    void LateUpdate()
    {
        Vector3 dest = transform.position;
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            Vector3 pos = player.transform.position;
            dest.x = pos.x;
            dest.y = pos.y;
            transform.position = dest;
        }
    }
}
