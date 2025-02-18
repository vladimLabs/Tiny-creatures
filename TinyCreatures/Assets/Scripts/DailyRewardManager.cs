using System;
using UnityEngine;

public class DailyRewardManager : MonoBehaviour
{
    private const string LastLoginDateKey = "LastLoginDate";
    private const string NumberDateKey = "NumberDateKey";
    private int dayReward;
    [SerializeField] private GameObject panelNewReward;

    void Start()
    {
        dayReward = PlayerPrefs.GetInt(NumberDateKey);
        CheckAndGiveDailyReward();
    }
    private void CheckAndGiveDailyReward()
    {
        DateTime lastLoginDate;
        DateTime currentLoginDate = DateTime.Now.Date;

        // �������� �������� ��������� ���� ����� �� PlayerPrefs
        string lastLoginDateString = PlayerPrefs.GetString(LastLoginDateKey, string.Empty);

        if (!string.IsNullOrEmpty(lastLoginDateString))
        {
            lastLoginDate = DateTime.Parse(lastLoginDateString);

            // ���������, ��� �� ��� ���� � ������� ����
            if (lastLoginDate < currentLoginDate)
            {
                // ���� � ����� ����, ������ �������
                GiveDailyReward();
            }
        }
        else
        {
            // ��� ����������� ���� �����, ������ ��� ������ ����
            GiveDailyReward();
        }

        // ��������� ���� ���������� �����
        PlayerPrefs.SetString(LastLoginDateKey, currentLoginDate.ToString());
    }

    private void GiveDailyReward()
    {
        // ������ ������ �������
        dayReward++;
        PlayerPrefs.SetInt(NumberDateKey, dayReward);

        Debug.Log("������ ���������� �������!");
        panelNewReward.SetActive(true);
        RewardManager.GetDailyReward(dayReward);
    }
}