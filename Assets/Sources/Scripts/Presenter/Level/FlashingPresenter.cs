using CrazyRacing.Model;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FlashingPresenter : MonoBehaviour
{
    [SerializeField] private Color _targetColor;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.DOColor(_targetColor, Config.FlashingDuration).SetLoops(-1, LoopType.Yoyo);
    }
}
