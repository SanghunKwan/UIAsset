using UnityEngine;
using UnityEngine.Events;

public class InputEvent : MonoBehaviour
{
    public UnityEvent onCancel;

    public UnityEvent onJump;

    void OnCancel()
    {
        onCancel?.Invoke();
    }
    void OnJump()
    {
        onJump?.Invoke();
    }
}
