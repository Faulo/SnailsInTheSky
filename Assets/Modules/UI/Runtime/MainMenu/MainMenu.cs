using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene = "SC_L01_KidsRoom";

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStartGame      = root.Q<Button>("ButtonStartGame");
        Button buttonShowOptions    = root.Q<Button>("ButtonShowOptions");
        Button buttonShowCredits    = root.Q<Button>("ButtonShowCredits");
        Button buttonQuit           = root.Q<Button>("ButtonQuit");

        buttonStartGame.clicked += () => SceneManager.LoadScene(startScene);
        buttonQuit.clicked += () => Application.Quit();
    }
}
