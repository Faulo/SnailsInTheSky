using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public UIDocument uiDocument;

    public string startScene = "SC_L01_KidsRoom";

    private Button buttonStartGame;
    private Button buttonShowOptions;
    private Button buttonShowCredits;
    private Button buttonQuit;

    private VisualElement credits;

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;

        buttonStartGame   = root.Q<Button>("ButtonStartGame");
        buttonShowOptions = root.Q<Button>("ButtonShowOptions");
        buttonShowCredits = root.Q<Button>("ButtonShowCredits");
        buttonQuit        = root.Q<Button>("ButtonQuit");

        credits = root.Q<VisualElement>("Credits");

        buttonStartGame.clicked += () => SceneManager.LoadScene(startScene);
        buttonShowCredits.clicked += () => credits.visible = !credits.visible;
        buttonQuit.clicked += () => Application.Quit();

        buttonStartGame.Focus();

        Debug.Assert(buttonStartGame == GetComponent<UIDocument>().rootVisualElement.focusController.focusedElement);
    }
}
