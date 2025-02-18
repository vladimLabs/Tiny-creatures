using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    //public Slime currentSlime;
    public GameObject inputFieldName; // Объект с InputField
    public Button startButton; // Кнопка для начала новой игры

    void Start()
    {
        // Подписываемся на событие нажатия кнопки "Start"
        startButton.onClick.AddListener(StartNewGame);
    }

    void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        string name = inputFieldName.GetComponent<TMP_InputField>().text;
        //Save.NewGame(name);   //////////////////Вернуть, когда надо вводить имя вручную
        Save.NewGame("Слайми");
        InventorySave.StartNewGame();
        // Здесь можно добавить дополнительную логику для перехода в игру после установки имени
        RestartScene();
    }

    public void RestartScene()
    {
        // Получаем номер текущей сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Перезапускаем текущую сцену
        SceneManager.LoadScene(currentSceneIndex);
    }
}
