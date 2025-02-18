using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Slider joySlider;
    [SerializeField] private Slider satietySlider;

    public static HUD Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (GameController.Instance != null)
        {
            Slime slime = GameController.Instance.currentSlime;
            ShowStaticParametrs(slime);
        }
    }

    private void ShowStaticParametrs(Slime slime)
    {
        nameText.text = slime.name;
    }

    public void UpdateHUD(Slime slime)
    {
        joySlider.value = slime.joyLevel;
        satietySlider.value = slime.satietyLevel;
    }
}
