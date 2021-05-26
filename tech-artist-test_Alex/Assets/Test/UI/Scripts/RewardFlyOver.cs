using System.Collections;
using UnityEngine;
using DG.Tweening;

public class RewardFlyOver : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 startScale;

    [SerializeField]
    private Transform toTransform;

    [SerializeField]
    private float duration;

    [SerializeField]
    private Vector3 scaleTo;

    [SerializeField]
    private AnimationCurve easeCurveX;
    [SerializeField]
    private AnimationCurve easeCurveY;

    public void Start()
    {
        startPosition = transform.localPosition;
        startScale = transform.localScale;
    }

    public void StartFlyOver(TweenCallback callback)
    {
        gameObject.SetActive(true);
        StartCoroutine(FlyOver(callback));
    }

    private IEnumerator FlyOver(TweenCallback callback)
    {
        Tween myTweenX = transform.DOMoveX(toTransform.position.x, duration).SetEase(easeCurveX).OnComplete(callback);
        transform.DOMoveY(toTransform.position.y, duration).SetEase(easeCurveY);
        transform.DOScale(scaleTo, duration);
        yield return myTweenX.WaitForCompletion();
        gameObject.SetActive(false);
        ResetPosition();
    }

    public void ResetPosition()
    {
        transform.localPosition = startPosition;
        transform.localScale = startScale;
    }
}
