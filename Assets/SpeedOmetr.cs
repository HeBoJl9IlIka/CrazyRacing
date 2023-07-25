using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedOmetr : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentValue;
    [SerializeField] private TMP_Text _overclocking0_50;
    [SerializeField] private TMP_Text _overclocking0_100;
    [SerializeField] private TMP_Text _overclocking0_150;
    [SerializeField] private TMP_Text _overclocking0_200;
    [SerializeField] private TMP_Text _overclocking0_250;
    [SerializeField] private TMP_Text _overclocking0_300;
    [SerializeField] private TMP_Text _overclocking0_350;
    [SerializeField] private TMP_Text _overclocking0_400;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Button _reset;

    private float _time;

    void Update()
    {
        int speed = (int)(_rigidbody.velocity.magnitude * 3.6f);
        _currentValue.text = speed.ToString();

        if (speed != 0)
            _time += Time.deltaTime;
        else
            _time = 0;

        switch (speed)
        {
            case 50:
                _overclocking0_50.text = $"0-50: {(int)_time}";
                break;
            case 100:
                _overclocking0_100.text = $"0-100: {(int)_time}";
                break;
            case 150:
                _overclocking0_150.text = $"0-150: {(int)_time}";
                break;
            case 200:
                _overclocking0_200.text = $"0-200: {(int)_time}";
                break;
            case 250:
                _overclocking0_250.text = $"0-250: {(int)_time}";
                break;
            case 300:
                _overclocking0_300.text = $"0-300: {(int)_time}";
                break;
            case 350:
                _overclocking0_350.text = $"0-350: {(int)_time}";
                break;
            case 400:
                _overclocking0_400.text = $"0-400: {(int)_time}";
                break;
        }
    }

    private void OnEnable()
    {
        _reset.onClick.AddListener(Reset);
    }

    private void OnDisable()
    {
        _reset.onClick.RemoveListener(Reset);
    }

    private void Reset()
    {
        _overclocking0_50.text = "";
        _overclocking0_100.text = "";
        _overclocking0_150.text = "";
        _overclocking0_200.text = "";
        _overclocking0_250.text = "";
        _overclocking0_300.text = "";
        _overclocking0_350.text = "";
        _overclocking0_400.text = "";
    }
}
