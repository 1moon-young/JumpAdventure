using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Credits : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float offScreenPosition = 1150;

    private bool creditsSkipped;

    private void Update()
    {
        // Credits ������Ʈ ����ø���
        rect.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        if (rect.anchoredPosition.y > offScreenPosition)
        {
            GoToMainMenu();
        }
    }

    // Credits ������Ʈ ����ø��� �ӵ� ����
    public void SkipCredits()
    {
        if (creditsSkipped == false)
        {
            scrollSpeed *= 5;
            creditsSkipped = true;
        }
        else
        {
            GoToMainMenu();
        }
    }

    // ���� �޴� �̵� �Լ�
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



}
