using CrazyRacing.Model;
using UnityEngine;

public class TutorialMenuPresenter : MonoBehaviour
{
    [SerializeField] private ButtonContinuePresenter _buttonContinue;

    private GamePause _model;

    private void Start()
    {
        _model = new GamePause();
        _model.Pause();
    }

    private void OnEnable()
    {
        _buttonContinue.onClick.AddListener(OnContinued);
    }

    private void OnDisable()
    {
        _buttonContinue.onClick.RemoveListener(OnContinued);
    }

    private void OnContinued()
    {
        _model.Continue();
    }
}
