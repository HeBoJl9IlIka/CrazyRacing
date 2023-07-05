using CrazyRacing.Model;
using DG.Tweening;
using UnityEngine;

public class SizeChangerPresenter : MonoBehaviour
{
    [SerializeField] private Vector3 _targetSize;

    private void Start()
    {
        transform.DOScale(_targetSize, Config.FlashingDuration).SetLoops(-1, LoopType.Yoyo);
    }
}
