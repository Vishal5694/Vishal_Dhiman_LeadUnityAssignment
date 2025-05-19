using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Convai.Scripts.Runtime.Core;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance;

    [Header("UI")]
    public GameObject personaSelectorUIPrefab;

    [Header("Camera")]
    public Camera personaSelectorCamera;

    [Header("Optional")]
    public Transform fallbackSpawnPoint;

    private GameObject selectedNPC;
    private bool isSpawning = false;

    private void Awake() => Instance = this;

    private void Update()
    {
        if (isSpawning && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 50f))
            {
                LoadAndSpawnRandomNPC(hit.point);
            }
            else if (fallbackSpawnPoint != null)
            {
                LoadAndSpawnRandomNPC(fallbackSpawnPoint.position);
            }
            isSpawning = false;
        }
    }

    public void BeginSpawn()
    {
        isSpawning = true;
    }

    private void LoadAndSpawnRandomNPC(Vector3 position)
    {
        string address = (Random.value > 0.5f) ? "Assets/Prefabs/CIA_Final_1.prefab" : "Assets/Prefabs/Ira.prefab";

        Addressables.LoadAssetAsync<GameObject>(address).Completed += (AsyncOperationHandle<GameObject> handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                SpawnNPCAt(handle.Result, position);
            }
            else
            {
                Debug.LogError("❌ Failed to load NPC prefab: " + address);
            }
        };
    }

    private void SpawnNPCAt(GameObject prefab, Vector3 position)
    {
        Vector3 cameraDir = Camera.main.transform.position - position;
        cameraDir.y = 0;
        Quaternion lookRot = Quaternion.LookRotation(cameraDir);

        GameObject npc = Instantiate(prefab, position, lookRot);
        selectedNPC = npc;

        // Attach Persona Selector
        var canvasInstance = Instantiate(personaSelectorUIPrefab);
        canvasInstance.transform.SetParent(npc.transform);
        canvasInstance.transform.localPosition = new Vector3(0, 2.5f, 0);
        //canvasInstance.transform.localRotation = lookRot;
        personaSelectorUIPrefab.gameObject.GetComponent<Canvas>().worldCamera = personaSelectorCamera;

        var convai = npc.GetComponent<ConvaiNPC>();
        var selector = canvasInstance.GetComponent<PersonaSelector>();
        selector.Init(convai);
    }

    public void SetSelected(GameObject npc)
    {
        selectedNPC = npc;
    }

    public GameObject GetSelectedNPC() => selectedNPC;
}
