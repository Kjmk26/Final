using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OpcionesMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown screenModeDropdown;
    public Slider ambianceSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer; // Audio Mixer para controlar volúmenes

    private Resolution[] resolutions;
    private List<string> resolutionOptions = new List<string>();

    void Start()
    {
        // Configuracion de Resoluciones
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);

        for (int i = 0; i < resolutions.Length; i++)
        {
            string aspectRatio = GetAspectRatio(resolutions[i].width, resolutions[i].height);
            string resolutionText = resolutions[i].width + "x" + resolutions[i].height + " (" + aspectRatio + ")";
            resolutionOptions.Add(resolutionText);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Configuracion de Modo de Pantalla
        screenModeDropdown.ClearOptions();
        screenModeDropdown.AddOptions(new List<string> { "Pantalla Completa", "Ventana", "Sin Bordes" });
        screenModeDropdown.value = PlayerPrefs.GetInt("ScreenMode", 0);

        // Carga y aplicación de volúmenes guardados
        ambianceSlider.value = PlayerPrefs.GetFloat("AmbianceVolume", 0.8f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
        SetAmbianceVolume(ambianceSlider.value);
        SetSFXVolume(sfxSlider.value);

        // Asignación de eventos
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        screenModeDropdown.onValueChanged.AddListener(SetScreenMode);
        ambianceSlider.onValueChanged.AddListener(SetAmbianceVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreenMode);
        PlayerPrefs.SetInt("ResolutionIndex", index);
        PlayerPrefs.Save();
    }

    void SetScreenMode(int index)
    {
        FullScreenMode mode = FullScreenMode.FullScreenWindow;

        switch (index)
        {
            case 0:
                mode = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                mode = FullScreenMode.Windowed;
                break;
            case 2:
                mode = FullScreenMode.MaximizedWindow;
                break;
        }

        Screen.fullScreenMode = mode;
        PlayerPrefs.SetInt("ScreenMode", index);
        PlayerPrefs.Save();
    }

    void SetAmbianceVolume(float value)
    {
        audioMixer.SetFloat("AmbienceVolume", value > 0.0001f ? Mathf.Log10(value) * 20 : -80f);
        PlayerPrefs.SetFloat("AmbianceVolume", value);
        PlayerPrefs.Save();
    }

    void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", value > 0.0001f ? Mathf.Log10(value) * 20 : -80f);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }

    string GetAspectRatio(int width, int height)
    {
        float ratio = (float)width / height;
        if (Mathf.Approximately(ratio, 16f / 9f)) return "16:9";
        if (Mathf.Approximately(ratio, 16f / 10f)) return "16:10";
        if (Mathf.Approximately(ratio, 4f / 3f)) return "4:3";
        return "Otro";
    }
}
