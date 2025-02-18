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
        float decayRatePerHour = 8.33f; // Ќапример, дл€ сытости, где 100 единиц расходуютс€ за 12 часов
        //float decayRatePerHour = 50f; // Ќапример, дл€ сытости, где 100 единиц расходуютс€ за 12 часов

        float decayAmount = CalculateDecayAmount(elapsedTime, decayRatePerHour);
        //Debug.Log(decayAmount);
        GameController.Instance.ChangeParametrsOfLife(-decayAmount, -decayAmount);

        // ѕосле обработки не забудьте снова сохранить текущее врем€ дл€ следующего расчЄта
        SaveLastQuitTime();

        //text[0] = elapsedTime.ToString();
    }

    private void SaveLastQuitTime()
    {
        PlayerPrefs.SetString("LastQuitTime", DateTime.Now.ToBinary().ToString());
    }

    // —охранение времени выхода
    void OnApplicationQuit()
    {
        SaveLastQuitTime();
    }



    // –асчЄт прошедшего времени с последнего выхода
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

    // ¬ычисление количества единиц дл€ вычета из параметров счасть€ и сытости
    public float CalculateDecayAmount(TimeSpan elapsedTime, float decayRatePerHour)
    {
        // ѕреобразование времени в часы и умножение на скорость распада в час
        return (float)elapsedTime.TotalHours * decayRatePerHour;
    }
}