using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class UIHandlerMyGame : MonoBehaviour
{
    public static UIHandlerMyGame instance {  get; private set; }
    VisualElement m_HealthBar;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
		m_HealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1);
    }

    public void SetHealthValue(float percentage)
    {
		m_HealthBar.style.width = Length.Percent(100 * percentage);
	}
}
