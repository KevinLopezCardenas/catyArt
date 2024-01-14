using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlameMatch : MonoBehaviour, ILightable
{
    [SerializeField] private GameObject fireObject;
    [SerializeField] private VolumetricFire volumetricFire;

    public void Ignite()
    {
        fireObject.SetActive(true);
        SetAlpha(0.138f);
    }

    public void Extinguish()
    {
        SetAlpha(0.0f);
        fireObject.SetActive(false);
    }

    private void SetAlpha(float alphaValue)
    {
        volumetricFire.alpha = alphaValue;
    }
}