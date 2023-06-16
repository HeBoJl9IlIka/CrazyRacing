using CrazyRacing.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private ButtonSelectLevelPresenter _buttonSelect;
    [SerializeField] private GameObject _levelBlock;

    private Level _model;

    public void Init(Level level)
    {
        _model = level;
        enabled = true;
    }

    public void OnEnable()
    {
        _model.Unlocked += OnUnlocked;
        _buttonSelect.onClick.AddListener(OnSelected);
    }

    public void OnDisable()
    {
        _model.Unlocked -= OnUnlocked;
        _buttonSelect.onClick.RemoveListener(OnSelected);
    }

    private void OnSelected()
    {
        SceneManager.LoadScene(_model.NormalizedNumber);
    }

    private void OnUnlocked()
    {
        _levelBlock.SetActive(false);
    }
}
