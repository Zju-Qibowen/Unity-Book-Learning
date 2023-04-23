using UnityEngine;

[RequireComponent(typeof(Light))]
public class CoolLighting : MonoBehaviour
{
    [Tooltip("The color of the light.")] public Color lightColor = Color.white;

    [Tooltip("The intensity of the light.")]
    public float lightIntensity = 1f;

    [Tooltip("The range of the light.")] public float lightRange = 10f;

    [Tooltip("The angle of the light.")] public float lightAngle = 30f;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Start()
    {
        _light.color = lightColor;
        _light.intensity = lightIntensity;
        _light.range = lightRange;
        _light.spotAngle = lightAngle;
    }
}