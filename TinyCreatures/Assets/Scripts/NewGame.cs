using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    //public Slime currentSlime;
    public GameObject inputFieldName; // ������ � InputField
    public Button startButton; // ������ ��� ������ ����� ����

    void Start()
    {
        // ������������� �� ������� ������� ������ "Start"
        startButton.onClick.AddListener(StartNewGame);
    }

    void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        string name = inputFieldName.GetComponent<TMP_InputField>().text;
        //Save.NewGame(name);   //////////////////�������, ����� ���� ������� ��� �������
        Save.NewGame("������");
        InventorySave.StartNewGame();
        // ����� ����� �������� �������������� ������ ��� �������� � ���� ����� ��������� �����
        RestartScene();
    }

    public void RestartScene()
    {
        // �������� ����� ������� �����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������������� ������� �����
        SceneManager.LoadScene(currentSceneIndex);
    }
}
