using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    public Transform teleportTarget;   // 传送目标点（在Inspector中设置）
    private bool isPlayerInRange = false;  // 玩家是否在范围内

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
           
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            // 传送玩家到目标位置
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = teleportTarget.position;
            
        }
    }
}
