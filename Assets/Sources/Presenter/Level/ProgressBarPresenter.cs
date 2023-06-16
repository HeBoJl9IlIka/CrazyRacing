using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using CrazyRacing.Model;

public class ProgressBarPresenter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float _duration = Config.ProgressBarFillingDuration;

    public void Init(int amountCheckpoints)
    {
        _slider.gameObject.SetActive(true);
        _slider.maxValue = amountCheckpoints;
    }

    public void Add()
    {
        float value = _slider.value;
        ++value;
        _slider.DOValue(value, _duration);
    }
}
