using UnityEngine;

public class Slowmo : MonoBehaviour
{
    [SerializeField] private float _time;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.timeScale == _time)
                Time.timeScale = 1f;
            else
                Time.timeScale = _time;
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
