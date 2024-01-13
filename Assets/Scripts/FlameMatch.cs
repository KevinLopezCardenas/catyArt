using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMatch : MonoBehaviour, ILightable
{
    [SerializeField] private GameObject fireObject;

    public void Ignite()
    {
        fireObject.SetActive(true);
    }

    public void Extinguish()
    {
        fireObject.SetActive(false);
    }
}