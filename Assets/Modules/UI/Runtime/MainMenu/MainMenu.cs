using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour {
    [SerializeField]
    public UIDocument uiDocument;

    public string startScene = "SC_PlaneSelect";

    Button uiButtonStartGame;
    Button uiButtonShowOptions;
    Button uiButtonQuit;

    VisualElement uiCredits;

    protected void OnEnable() {
        var uiRoot = uiDocument.rootVisualElement;

        uiButtonStartGame = uiRoot.Q<Button>("ButtonStartGame");
        uiButtonShowOptions = uiRoot.Q<Button>("ButtonShowOptions");
        uiButtonQuit = uiRoot.Q<Button>("ButtonQuit");

        uiCredits = uiRoot.Q<VisualElement>("Credits");

        uiButtonStartGame.clicked += () => SceneManager.LoadScene(startScene);
        uiButtonQuit.clicked += () => Application.Quit();

        uiButtonStartGame.Focus();

        Debug.Assert(uiButtonStartGame == GetComponent<UIDocument>().rootVisualElement.focusController.focusedElement);
    }
}
