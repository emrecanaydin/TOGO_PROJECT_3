using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnimation : MonoBehaviour
{

    void Start()
    {
        InvokeRepeating("horizontalMove", 0f, 1f);
    }

    public void horizontalMove()
    {
        transform.position = new Vector3(Random.Range(-1, 2) * 2, transform.position.y, transform.position.z);
    }

}
