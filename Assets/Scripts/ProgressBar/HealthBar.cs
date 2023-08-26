using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [field: SerializeField] public RectTransform RectTransform { get; set; }
    [field: SerializeField] public Image FrontImage { get; set; }
    [field: SerializeField] public Image BackImage { get; set; }
}
