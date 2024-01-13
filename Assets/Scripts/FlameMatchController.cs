using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMatchController : MonoBehaviour
{
    [Serializable]
    public class FlameMatchContainer
    {
        public float ignitionTime = 1f;
        public bool remainLighted = false;
        public FlameMatch FlameMatch;
    }

    [SerializeField] private List<FlameMatchContainer> matches;

    [ContextMenu("IgniteMatches")]
    public void IgniteMatches()
    {
        StartCoroutine(IgniteMatchesSequentially());
    }

    private IEnumerator IgniteMatchesSequentially()
    {
        foreach (var matchContainer in matches)
        {
            matchContainer.FlameMatch.Ignite();

            yield return new WaitForSeconds(matchContainer.ignitionTime);

            if (!matchContainer.remainLighted)
            {
                matchContainer.FlameMatch.Extinguish();
            }
        }
    }
}