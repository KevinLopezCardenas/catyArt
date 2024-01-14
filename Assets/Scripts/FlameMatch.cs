using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class FlameMatch : MonoBehaviour, ILightable
{
    [SerializeField] private GameObject fireObject;
    [SerializeField] private VolumetricFire volumetricFire;
    private Tween _alphaTween;
    private Tween _fireSizeTween;

    public void Ignite()
    {
        fireObject.SetActive(true);
        SetAlpha(0.138f, 0.7f, 1f);
    }

    public void Extinguish()
    {
        _alphaTween.Kill();
        _fireSizeTween.Kill();
        SetAlpha(0.0f, 0f, 0.5f, () => { fireObject.SetActive(false); });
    }

    private void SetAlpha(float alphaValue, float outerFireSizeValue, float interpolationTime = 2f,
        Action callback = null)
    {
        _alphaTween = DOTween.To(() => volumetricFire.alpha, x => volumetricFire.alpha = x, alphaValue,
                interpolationTime)
            .SetUpdate(true);
        _fireSizeTween = DOTween.To(() => volumetricFire.outerFireSize, x => volumetricFire.outerFireSize = x,
                outerFireSizeValue,
                interpolationTime)
            .SetUpdate(true).OnComplete(() => { callback?.Invoke(); });
    }
}