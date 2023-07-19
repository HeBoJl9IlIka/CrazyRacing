using CrazyRacing.Model;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [Header("Presenters templates")]
    [SerializeField] private PauseMenuPresenter _pauseMenuPresenter;
    [SerializeField] private CompletedMenuPresenter _completedMenuPresenter;
    [SerializeField] private SkippingLevelPresenter _skippingLevelPresenter;
    [SerializeField] private ProgressBarPresenter _progressBarPresenter;
    [SerializeField] private MusicPresenter _musicPresenter;

    public void CreatePauseMenu(GamePause pauseGame)
    {
        PauseMenuPresenter pauseGamePresenter = Instantiate(_pauseMenuPresenter);
        pauseGamePresenter.Init(pauseGame);
    }

    public void CreateCompletedMenu(GamePause pauseGame)
    {
        CompletedMenuPresenter completedMenuPresenter = Instantiate(_completedMenuPresenter);
        completedMenuPresenter.Init(pauseGame);
    }

    public void CreateSkippingMenu(GamePause pauseGame)
    {
        SkippingLevelPresenter skippingLevelPresenter = Instantiate(_skippingLevelPresenter);
        skippingLevelPresenter.Init(pauseGame);
    }

    public ProgressBarPresenter CreateProgressBar(int amountCheckpoints)
    {
        ProgressBarPresenter progressBarPresenter = Instantiate(_progressBarPresenter);
        progressBarPresenter.Init(amountCheckpoints);

        return progressBarPresenter;
    }

    public void CreateMusicPresenter()
    {
        MusicPresenter musicPresenter = Instantiate(_musicPresenter);
    }
}
