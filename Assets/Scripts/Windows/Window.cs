using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;

    protected CanvasGroup CanvasGroup => _canvasGroup;
    protected Button Button => _button;

    public virtual void Open(float alpha, bool isInteractable)
    {
        CanvasGroup.alpha = alpha;
        CanvasGroup.interactable = isInteractable;
    }

    public virtual void Closed(float alpha, bool isInteractable)
    {
        CanvasGroup.alpha = alpha;
        CanvasGroup.interactable = isInteractable;
    }
}