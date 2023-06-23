using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightControl : MonoBehaviour
{
    public Light spotLight; // Ссылка на компонент SpotLight
    public Button toggleButton; // Ссылка на кнопку

    private bool isSpotlightEnabled; // Флаг для отслеживания состояния SpotLight

    private void Start()
    {
        // По умолчанию включаем SpotLight
        isSpotlightEnabled = true;

        // Назначаем метод OnButtonClick() на событие нажатия кнопки
        toggleButton.onClick.AddListener(ToggleSpotlightState);
    }

    private void ToggleSpotlightState()
    {
        // Если SpotLight включен, то отключаем его, и наоборот
        if (isSpotlightEnabled)
        {
            spotLight.enabled = false;
        }
        else
        {
            spotLight.enabled = true;
        }

        // Инвертируем состояние флага
        isSpotlightEnabled = !isSpotlightEnabled;
    }
}
