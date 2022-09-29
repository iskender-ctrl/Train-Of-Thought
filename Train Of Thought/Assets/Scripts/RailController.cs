using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailController : MonoBehaviour
{
    public void ClickToRail(GameObject rail)
    {
        rail.SetActive(true);
        gameObject.SetActive(false);
    }
}
