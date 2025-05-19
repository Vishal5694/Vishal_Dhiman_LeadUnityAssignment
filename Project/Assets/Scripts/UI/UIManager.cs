using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Button addButton, removeButton, ciaButton, airaButton;
    public Text selectedText;
    public Text dialogText;

    void Awake() => Instance = this;

    void Start()
    {
        //addButton.onClick.AddListener(() => NPCManager.Instance.BeginSpawn());
        //removeButton.onClick.AddListener(() => NPCManager.Instance.RemoveSelected());

        //ciaButton.onClick.AddListener(() =>
        //    NPCManager.Instance.AssignPersona("YOUR_CIA_CHARACTER_ID"));  // Replace
        //airaButton.onClick.AddListener(() =>
        //    NPCManager.Instance.AssignPersona("YOUR_AIRA_CHARACTER_ID")); // Replace
    }

    public void UpdateSelected(string npcName)
    {
        selectedText.text = $"Selected NPC: {npcName}";
    }

    public void ShowDialog(string message)
    {
        dialogText.text = $"NPC Says: {message}";
    }
}
