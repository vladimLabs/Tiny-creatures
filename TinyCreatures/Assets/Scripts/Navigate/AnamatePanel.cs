using UnityEngine;
using UnityEngine.UI;

public class AnamatePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private bool isShow = true;

    public void Show()
    {
        isShow = !isShow;
        panel.GetComponent<Animator>().SetBool("show", isShow);
    }
}