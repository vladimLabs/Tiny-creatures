using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image foodImage; // ���������� ������, �� ������� � ����������
    [SerializeField] private TextMeshProUGUI nameText; // �� �� ��� ������ ��������
    [SerializeField] private TextMeshProUGUI quantityText; // �� �� ��� ������ ����������
    [SerializeField] private TextMeshProUGUI satietyBonusText; // �� �� ��� ������ ������ �������
    [SerializeField] private TextMeshProUGUI happinessBonusText; // �� �� ��� ������ ������ �������

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