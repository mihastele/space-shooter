using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleClickCommand : MonoBehaviour
{

    [SerializeField] Player player;


    public void ClickShoot()
    {
        player.Fire();
    }
}
