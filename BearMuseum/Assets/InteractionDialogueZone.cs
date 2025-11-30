    using UnityEngine;
using TMPro;

public class InteractionDialogueZone : MonoBehaviour
{
    [Header("交互提示 UI")]
    public TextMeshProUGUI interactText;   // 比如屏幕下方的 "Press E to interact"

    [Header("对话 UI")]
    public GameObject dialoguePanel;       // 显示对话的 Panel
    public TextMeshProUGUI dialogueText;   // Panel 里的文本

    [Header("本区域的对话内容")]
    [TextArea(2, 4)]
    public string[] lines;                 // 一行一句，可以在 Inspector 里填

    [Header("按键设置")]
    public KeyCode interactKey = KeyCode.E;  // 按下 E 开始交互
    public bool useAnyKeyForNextLine = true; // true = 任意键切下一行

    private bool playerInRange = false;    // 玩家是否在这个范围内
    private bool isTalking = false;        // 是否正在对话中
    private int lineIndex = 0;             // 当前是第几句
        

    void Start()
    {
        // 一开始隐藏提示和对话
        if (interactText != null)
            interactText.gameObject.SetActive(false);

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            // 玩家进范围，如果当前没在对话，就显示 “Press E to interact”
            if (!isTalking && interactText != null)
            {
                interactText.text = "Press E to interact";
                interactText.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // 离开范围时，关掉提示和对话
            if (interactText != null)
                interactText.gameObject.SetActive(false);

            if (dialoguePanel != null)
                dialoguePanel.SetActive(false);

            isTalking = false;
            lineIndex = 0;
        }
    }

    void Update()
    {
        // 不在范围里就不处理
        if (!playerInRange) return;

        // ① 还没开始对话：按 E 开始
        if (!isTalking)
        {
            if (Input.GetKeyDown(interactKey))
            {
                StartDialogue();
            }
        }
        // ② 对话中：按任意键（或指定键）切下一行
        else
        {
            bool next = false;

            if (useAnyKeyForNextLine)
            {
                if (Input.anyKeyDown) next = true;
            }
            else
            {
                // 如果你以后想限定，比如按 space 才换行，可以在这里改
                if (Input.GetKeyDown(KeyCode.Space)) next = true;
            }

            if (next)
            {
                ShowNextLine();
            }
        }
    }

    void StartDialogue()
    {
        if (lines == null || lines.Length == 0 || dialoguePanel == null || dialogueText == null)
            return;

        isTalking = true;
        lineIndex = 0;

        // 开始对话时隐藏 “Press E to interact”
        if (interactText != null)
            interactText.gameObject.SetActive(false);

        dialoguePanel.SetActive(true);
        dialogueText.text = lines[lineIndex];
    }

    void ShowNextLine()
    {
        lineIndex++;

        if (lineIndex >= lines.Length)
        {
            // 对话结束
            EndDialogue();
        }
        else
        {
            dialogueText.text = lines[lineIndex];
        }
    }

    void EndDialogue()
    {
        isTalking = false;
        lineIndex = 0;

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        // 如果玩家还在范围里面，就再次显示 “Press E to interact”
        if (playerInRange && interactText != null)
        {
            interactText.text = "Press E to interact";
            interactText.gameObject.SetActive(true);
        }
    }
}
