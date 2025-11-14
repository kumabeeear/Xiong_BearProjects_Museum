using UnityEngine;
using TMPro;

public class DoorConsole : MonoBehaviour
{
    [Header("UI")]
    public GameObject promptPanel;         // 提示的 Panel（在 Canvas 里的）
    public TextMeshProUGUI promptText;     // Panel 上的文字

    [Header("Doors (墙体)")]
    public GameObject room1Door;           // 房间 1 的墙/门
    public GameObject room2Door;           // 房间 2 的墙/门
    public GameObject room3Door;           // 房间 3 的墙/门
    public GameObject room4Door;           // 房间 4 的墙/门

    private bool playerInRange = false;

    void Start()
    {
        // 一开始隐藏提示 Panel
        if (promptPanel != null)
            promptPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (promptPanel != null)
                promptPanel.SetActive(true);

            if (promptText != null)
                promptText.text = "Press room number (1-4) on your keyboard to open the door here";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (promptPanel != null)
                promptPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!playerInRange) return;

        // 玩家在范围内时，监听按键 1~4
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (room1Door != null) room1Door.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (room2Door != null) room2Door.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (room3Door != null) room3Door.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (room4Door != null) room4Door.SetActive(false);
        }

        // 如果你也想支持小键盘：Keypad1 ~ Keypad4 可以再加一组
    }
}
