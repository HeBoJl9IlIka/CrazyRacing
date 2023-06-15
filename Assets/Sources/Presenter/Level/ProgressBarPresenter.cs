using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using CrazyRacing.Model;

[RequireComponent(typeof(Slider))]
public class ProgressBarPresenter : MonoBehaviour
{
    private Slider _slider;
    private float _duration = Config.ProgressBarFillingDuration;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void Init(int amountCheckpoints)
    {
        gameObject.SetActive(true);
        _slider.maxValue = amountCheckpoints;
    }

    public void Add()
    {
        float number = _slider.value;
        ++number;
        _slider.DOValue(number, _duration);
    }
}
