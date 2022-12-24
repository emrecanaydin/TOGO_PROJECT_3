using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IDragHandler
{

    public Transform player;
    public Transform child;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = player.position;
        position.x = Mathf.Clamp(position.x + (eventData.delta.x / 100), -3.79f, 3.79f);
        player.position = position;

        Quaternion rotation = child.rotation;
        rotation.y = Mathf.Clamp(rotation.y + (eventData.delta.x / 500), -.2f, 2f);
        child.rotation = rotation;
    }

}
