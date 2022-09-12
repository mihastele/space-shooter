using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityFireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] Player player;
    public UnityEventQueueSystem onLongClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("DOWN");
        player.Fire();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("UP");
        player.StopFire();
    }

}
