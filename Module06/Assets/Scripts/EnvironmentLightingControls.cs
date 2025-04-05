using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class EnvironmentLightingControls : MonoBehaviour
{
    public Toggle useSkyboxToggle;
    public Slider skyboxIntensitySlider;
    public TMP_Text skyboxIntensityText;

    public Toggle enableFog;

    public bool EnableFog
    {
        get => RenderSettings.fog;
        set => RenderSettings.fog = value;
    }

    public bool UseSkybox
    {
        get => (RenderSettings.ambientMode == AmbientMode.Skybox);
        set
        {
            RenderSettings.ambientMode = (value) ?
               AmbientMode.Skybox : AmbientMode.Flat;
            skyboxIntensitySlider.interactable = value;
            skyboxIntensityText.gameObject.SetActive(value);
        }
    }

    public float SkyboxIntensity
    {
        get => RenderSettings.ambientIntensity;
        set
        {
            RenderSettings.ambientIntensity = value;
            skyboxIntensityText.text = value.ToString("F1");
        }
    }

    private void Start()
    {
        useSkyboxToggle.isOn = UseSkybox;
        skyboxIntensitySlider.value = SkyboxIntensity;
        enableFog.isOn = EnableFog;
    }
}