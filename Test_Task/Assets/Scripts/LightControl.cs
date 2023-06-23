using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightControl : MonoBehaviour
{
    public Light spotLight; // ������ �� ��������� SpotLight
    public Button toggleButton; // ������ �� ������

    private bool isSpotlightEnabled; // ���� ��� ������������ ��������� SpotLight

    private void Start()
    {
        // �� ��������� �������� SpotLight
        isSpotlightEnabled = true;

        // ��������� ����� OnButtonClick() �� ������� ������� ������
        toggleButton.onClick.AddListener(ToggleSpotlightState);
    }

    private void ToggleSpotlightState()
    {
        // ���� SpotLight �������, �� ��������� ���, � ��������
        if (isSpotlightEnabled)
        {
            spotLight.enabled = false;
        }
        else
        {
            spotLight.enabled = true;
        }

        // ����������� ��������� �����
        isSpotlightEnabled = !isSpotlightEnabled;
    }
}
