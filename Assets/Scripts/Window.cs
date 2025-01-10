using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;

    protected CanvasGroup CanvasGroup => _canvasGroup;
    protected Button Button => _button;

    public abstract void Open();

    public abstract void Closed();
}