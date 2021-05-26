using UnityEngine;
using TMPro;

public class CongratulationsPanel : MonoBehaviour
{
    private int counterNum;
    [SerializeField]
    private GameObject[] starTweens;
    [SerializeField]
    private ParticleSystem starParticles;
    [SerializeField]
    private TextMeshProUGUI counterText;

    public void StartFlyover (int tweenIndex)
    {
        RewardFlyOver tweenPos = starTweens[tweenIndex].GetComponent<RewardFlyOver>();
        tweenPos?.StartFlyOver(FlyoverComplete);
    }

    private void FlyoverComplete ()
    {
        starParticles.Play();
        CounterIncrement();
    }

    public void CounterIncrement()
    {
        counterNum++;
        counterText.text = counterNum.ToString();
    }
}
