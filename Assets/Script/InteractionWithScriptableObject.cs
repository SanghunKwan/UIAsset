using UnityEngine;

public class InteractionWithScriptableObject : MonoBehaviour
{
    [SerializeField] AudioSourceObject savedScriptableObject;
    [SerializeField] Component linkedComponent;


    private void Awake()
    {
        savedScriptableObject.SetDataType(linkedComponent);
    }

    public void SetValue(float value)
    {

    }
}
