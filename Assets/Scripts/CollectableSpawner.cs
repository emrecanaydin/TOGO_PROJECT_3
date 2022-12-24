using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{

    public GameObject collectable;

    void Start()
    {
        InvokeRepeating("CreateCollectable", 1f, 3f);
    }

    void CreateCollectable()
    {
        Vector3 collectablePosition = transform.position;
        Instantiate(collectable, collectablePosition, Quaternion.identity);
    }

}
