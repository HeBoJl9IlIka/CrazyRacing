using CrazyRacing.Model;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private PauseGamePresenter _pauseGamePresenter;
    [SerializeField] private CompletedMenuPresenter _completedMenuPresenter;
    [SerializeField] private SkippingLevelPresenter _skippingLevelPresenter;

    public void CreatePauseGame(PauseGame pauseGame)
    {
        PauseGamePresenter pauseGamePresenter = Instantiate(_pauseGamePresenter);
        pauseGamePresenter.Init(pauseGame);
    }

    public void CreateCompletedMenu(PauseGame pauseGame)
    {
        CompletedMenuPresenter completedMenuPresenter = Instantiate(_completedMenuPresenter);
        completedMenuPresenter.Init(pauseGame);
    }

    public void CreateSkippingMenu(PauseGame pauseGame)
    {
        SkippingLevelPresenter skippingLevelPresenter = Instantiate(_skippingLevelPresenter);
        skippingLevelPresenter.Init(pauseGame);
    }
}
