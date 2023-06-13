using System;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    private ButtonSelectLevelView _buttonSelect;
    private LevelBlockView _levelBlock;

    public event Action Selected;

    private void Awake()
    {
        _levelBlock = GetComponentInChildren<LevelBlockView>();
        _buttonSelect = GetComponentInChildren<ButtonSelectLevelView>();
    }

    private void OnEnable()
    {
        _buttonSelect.onClick.AddListener(OnSelected);
    }

    private void OnDisable()
    {
        _buttonSelect.onClick.RemoveListener(OnSelected);
    }

    public void Unlock()
    {
        _levelBlock.gameObject.SetActive(false);
    }

    private void OnSelected()
    {
        Selected?.Invoke();
    }
}
