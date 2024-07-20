using UnityEngine;
using UnityEngine.UI;

public class InputButton : MonoBehaviour
{
    public enum Directions
    {
        Right,
        Left,
        Back,
        Forward,
    }

    [field:SerializeField] public Directions ButtonDirection { get; private set; }
    [field:SerializeField] public Button Button { get; private set; }
}