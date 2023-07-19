using CrazyRacing.Model;
using UnityEngine;
using UnityEngine.UI;

public class AudioPresenter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _iconEnabled;
    [SerializeField] private Sprite _iconDisabled;

    private void Awake()
    {
        if (Audio.IsEnabled)
        {
            Audio.Enable();
            _image.sprite = _iconEnabled;
        }
        else
        {
            Audio.Disable();
            _image.sprite = _iconDisabled;
        }
    }

    private void Update()
    {
        if (Audio.IsEnabled)
        {
            if (GamePauseController.IsPaused == false)
                Audio.Enable();
            else
                Audio.Disable();
        }
        else
        {
            Audio.Disable();
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        Audio.Switch();

        if (Audio.IsEnabled)
            _image.sprite = _iconEnabled;
        else
            _image.sprite = _iconDisabled;
    }
}
