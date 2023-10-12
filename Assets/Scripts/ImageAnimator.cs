using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public sealed class ImageAnimator : MonoBehaviour
{
    [SerializeField] public Image image;
    [SerializeField] public bool fromStart;
    [SerializeField] public float totalTime = 1.75f;

    [SerializeField] public bool autoStart = true;

    private float _alpha;

    public void Start()
    {
        if (autoStart)
            StartCoroutine(Animate());
    }

    public IEnumerator Animate([CanBeNull] Action callback = null)
    {
        image.enabled = true;
        
        while (_alpha < 1)
        {
            _alpha += 1 / totalTime * Time.deltaTime;

            var color = image.color;
            color.a = fromStart ? _alpha : 1 - _alpha;
            image.color = color;

            yield return new WaitForEndOfFrame();
        }

        callback?.Invoke();
        image.enabled = false;
    }
}