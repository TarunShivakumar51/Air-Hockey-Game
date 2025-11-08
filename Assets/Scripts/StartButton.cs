using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Air Hockey";

    void Start()
    {
        // Get the Button component and link the click
        Button btn = GetComponent<Button>();

        btn.onClick.AddListener(OnStartClicked);
    }

    private void OnStartClicked()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
