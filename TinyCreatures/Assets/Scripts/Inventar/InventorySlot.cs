using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image foodImage; // Защищённый доступ, но видимый в инспекторе
    [SerializeField] private TextMeshProUGUI nameText; // То же для текста названия
    [SerializeField] private TextMeshProUGUI quantityText; // То же для текста количества
    [SerializeField] private TextMeshProUGUI satietyBonusText; // То же для текста бонуса сытости
    [SerializeField] private TextMeshProUGUI happinessBonusText; // То же для текста бонуса счастья

    private Food _food;

    public void SetInfo(int quantity, Food food)
    {
        _food = food;
        //foodImage.sprite = foodSprite;
        nameText.text = food.name;
        quantityText.text = $"{quantity}";
        satietyBonusText.text = $"{food.satietyBonus}";
        happinessBonusText.text = $"{food.happinessBonus}";
    }

    public void Feeding()
    {
        GameController.Instance.Feeding(_food, -1);
    }
}