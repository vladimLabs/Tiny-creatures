using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI[] text;


    void Start()
    {
        TimeSpan elapsedTime = CalculateElapsedTime();
        //Debug.Log(elapsedTime);
        float decayRatePerHour = 8.33f; // ��������, ��� �������, ��� 100 ������ ����������� �� 12 �����
        //float decayRatePerHour = 50f; // ��������, ��� �������, ��� 100 ������ ����������� �� 12 �����

        float decayAmount = CalculateDecayAmount(elapsedTime, decayRatePerHour);
        //Debug.Log(decayAmount);
        GameController.Instance.ChangeParametrsOfLife(-decayAmount, -decayAmount);

        // ����� ��������� �� �������� ����� ��������� ������� ����� ��� ���������� �������
        SaveLastQuitTime();

        //text[0] = elapsedTime.ToString();
    }

    private void SaveLastQuitTime()
    {
        PlayerPrefs.SetString("LastQuitTime", DateTime.Now.ToBinary().ToString());
    }

    // ���������� ������� ������
    void OnApplicationQuit()
    {
        SaveLastQuitTime();
    }



    // ������ ���������� ������� � ���������� ������
    public TimeSpan CalculateElapsedTime()
    {
        if (PlayerPrefs.HasKey("LastQuitTime"))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString("LastQuitTime"));
            DateTime oldDate = DateTime.FromBinary(temp);
            TimeSpan difference = DateTime.Now.Subtract(oldDate);
            return difference;
        }
        return TimeSpan.Zero;
    }

    // ���������� ���������� ������ ��� ������ �� ���������� ������� � �������
    public float CalculateDecayAmount(TimeSpan elapsedTime, float decayRatePerHour)
    {
        // �������������� ������� � ���� � ��������� �� �������� ������� � ���
        return (float)elapsedTime.TotalHours * decayRatePerHour;
    }
}