using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBarView : MonoBehaviour
{
    [SerializeField] private float _duration = 1;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void Init(int amountCheckpoints)
    {
        _slider.maxValue = amountCheckpoints;
    }

    public void Add(int currentNumber)
    {
        _slider.DOValue(currentNumber, _duration);
    }
}
