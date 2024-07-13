using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour {
    [SerializeField]
    public UIDocument uiDocument;

    public string startScene = "SC_PlaneSelect";

    Button uiButtonStartGame;
    Button uiButtonShowOptions;
    Button uiButtonShowCredits;
    Button uiButtonQuit;

    VisualElement uiCredits;

    protected void OnEnable() {
        var uiRoot = uiDocument.rootVisualElement;

        uiButtonStartGame = uiRoot.Q<Button>("ButtonStartGame");
        uiButtonShowOptions = uiRoot.Q<Button>("ButtonShowOptions");
        uiButtonShowCredits = uiRoot.Q<Button>("ButtonShowCredits");
        uiButtonQuit = uiRoot.Q<Button>("ButtonQuit");

        uiCredits = uiRoot.Q<VisualElement>("Credits");

        uiButtonStartGame.clicked += () => SceneManager.LoadScene(startScene);
        uiButtonShowCredits.clicked += () => uiCredits.visible = !uiCredits.visible;
        uiButtonQuit.clicked += () => Application.Quit();

        uiButtonStartGame.Focus();

        Debug.Assert(uiButtonStartGame == GetComponent<UIDocument>().rootVisualElement.focusController.focusedElement);
    }
}
