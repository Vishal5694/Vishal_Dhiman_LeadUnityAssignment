using UnityEngine;
using UnityEngine.UI;
using Convai.Scripts;
using Convai.Scripts.Runtime.Core;
using Convai.Scripts.Runtime.Features;

public class PersonaSelector : MonoBehaviour
{
    [Header("Buttons")]
    public Button ciaButton;
    public Button airaButton;
    public Button removeButton;

    private ConvaiNPC targetConvai;

    [Header("Character IDs")]
    public string ciaCharacterId = "479ceb76-21ce-11f0-af55-42010a7be01a";
    public string airaCharacterId = "35a2c95c-29b9-11f0-88ec-42010a7be01d";

    [Header("Names")]
    public string ciaName = "Cia";
    public string airaName = "Aira";

    public void Init(ConvaiNPC convai)
    {
        targetConvai = convai;

        ciaButton.onClick.AddListener(() => AssignPersona(ciaCharacterId, ciaName));
        airaButton.onClick.AddListener(() => AssignPersona(airaCharacterId, airaName));
        removeButton.onClick.AddListener(RemoveNPC);
    }

    void AssignPersona(string characterId, string characterName)
    {
        if (targetConvai != null)
        {
            targetConvai.characterID = characterId;
            targetConvai.gameObject.name = $"NPC_{characterName}";
            targetConvai.gameObject.AddComponent<NarrativeDesignManager>();
        }

        Destroy(gameObject);
    }

    void RemoveNPC()
    {
        if (targetConvai != null)
        {
            Destroy(targetConvai.gameObject);
        }

        Destroy(gameObject);
    }
}
