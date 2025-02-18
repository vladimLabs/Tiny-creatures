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

        // Пытаемся получить последнюю дату входа из PlayerPrefs
        string lastLoginDateString = PlayerPrefs.GetString(LastLoginDateKey, string.Empty);

        if (!string.IsNullOrEmpty(lastLoginDateString))
        {
            lastLoginDate = DateTime.Parse(lastLoginDateString);

            // Проверяем, был ли уже вход в текущий день
            if (lastLoginDate < currentLoginDate)
            {
                // Вход в новый день, выдаем награду
                GiveDailyReward();
            }
        }
        else
        {
            // Нет сохраненной даты входа, значит это первый вход
            GiveDailyReward();
        }

        // Обновляем дату последнего входа
        PlayerPrefs.SetString(LastLoginDateKey, currentLoginDate.ToString());
    }

    private void GiveDailyReward()
    {
        // Логика выдачи награды
        dayReward++;
        PlayerPrefs.SetInt(NumberDateKey, dayReward);

        Debug.Log("Выдана ежедневная награда!");
        panelNewReward.SetActive(true);
        RewardManager.GetDailyReward(dayReward);
    }
}