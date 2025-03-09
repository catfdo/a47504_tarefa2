using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance; // Adicionando Singleton

    private VisualElement m_Healthbar;

    void Awake()
    {
        // Configurar Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);
    }

    public void SetHealthValue(float percentage)
    {
        if (m_Healthbar != null) 
        {
            m_Healthbar.style.width = Length.Percent(100 * percentage);
        }
        else
        {
            Debug.LogError("HealthBar não foi encontrado! Verifique se o UIDocument está correto.");
        }
    }
}
