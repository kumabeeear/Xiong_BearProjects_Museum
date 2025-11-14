using UnityEngine;
using TMPro;   // ★ 如果用 TextMeshPro，记得加这一行

public class TeleportZone : MonoBehaviour
{
    [Header("Teleport")]
    public Transform teleportTarget;          // 传送目标点（在 Inspector 中设置）

    [Header("UI 提示")]
    public TextMeshProUGUI pressFText;        // 屏幕上显示 “Press F to enter” 的文字

    private bool isPlayerInRange = false;     // 玩家是否在范围内

    void Start()
    {
        // 一开始先隐藏提示
        if (pressFText != null)
        {
            pressFText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            if (pressFText != null)
            {
                pressFText.text = "Press F to enter";
                pressFText.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (pressFText != null)
            {
                pressFText.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            // 传送玩家到目标位置
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = teleportTarget.position;

            // 传送完也可以把提示关掉（可选）
            if (pressFText != null)
            {
                pressFText.gameObject.SetActive(false);
            }

            // 如果你要传送后不再触发，可以在这里把 isPlayerInRange 设为 false
            // isPlayerInRange = false;
        }
    }
}
