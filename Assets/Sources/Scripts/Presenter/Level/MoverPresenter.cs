using UnityEngine;
using DG.Tweening;

public class MoverPresenter : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private float _duration;

    private void Start()
    {
        transform.DOMove(_targetPosition, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
