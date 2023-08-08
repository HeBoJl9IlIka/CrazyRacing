using CrazyRacing.Model;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TutorialMenuPresenter _desktopTutorial;
    [SerializeField] private TutorialMenuPresenter _mobileTutorial;

    private void Awake()
    {
        if (SdkFactory.Sdk.IsMobile)
            _mobileTutorial.gameObject.SetActive(true);
        else
            _desktopTutorial.gameObject.SetActive(true);
    }
}
