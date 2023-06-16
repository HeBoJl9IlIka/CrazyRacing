using CrazyRacing.Model;
using UnityEngine;

public class AudioPresenter : MonoBehaviour
{
    private void Awake()
    {
        if (Audio.IsEnabled)
            Audio.Enable();
        else
            Audio.Disable();
    }

    public void Switch()
    {
        Audio.Switch();
    }
}
