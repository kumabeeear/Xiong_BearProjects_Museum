using UnityEngine;
using TMPro;

public class IntroDialogue : MonoBehaviour
{
    [Header("UI 组件")]
    public GameObject introPanel;         // 半透明 panel
    public TextMeshProUGUI introText;     // 显示文字的 Text
    [TextArea(2, 4)]
    public string[] lines;                // 每一句导语

    int index = 0;
    bool isPlayingIntro = true;

    void Start()
    {
        // 显示导语 Panel
        introPanel.SetActive(true);
        index = 0;
        introText.text = lines[index];

        // 暂停游戏里的物理和移动
        Time.timeScale = 0f;

        // 解锁鼠标，显示光标（可选，看你需不需要）
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (!isPlayingIntro) return;

        // 任意一个条件触发都可以：
        if (Input.GetMouseButtonDown(0) ||       // 鼠标左键
            Input.GetKeyDown(KeyCode.Space) ||   // 空格
            Input.anyKeyDown)                    // 任意键
        {
            NextLine();
        }
    }

    void NextLine()
    {
        index++;

        if (index >= lines.Length)
        {
            isPlayingIntro = false;

    // 关掉 panel
    introPanel.SetActive(false);

    // 保险起见，顺便把文字对象也关掉
    introText.gameObject.SetActive(false);

    Time.timeScale = 1f;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
        }
        else
        {
            introText.text = lines[index];
        }
    }
}
