using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 使用陣列儲存路徑點：起點 -> 往前走 -> 上跳 -> 下跳到終點
    public Vector3[] waypoints;
    public float speed = 3.0f;
    private int currentWaypointIndex = 0;

    void Start()
    {
        // 實例化陣列並使用 Vector 設定各個節點
        waypoints = new Vector3[4];
        waypoints[0] = transform.position; // 0: 初始位置
        waypoints[1] = transform.position + new Vector3(3, 0, 0); // 1: 往前走
        waypoints[2] = waypoints[1] + new Vector3(2, 3, 0);       // 2: 上跳
        waypoints[3] = waypoints[2] + new Vector3(2, -3, 0);      // 3: 下跳到終點
    }

    void Update()
    {
        // 只要還沒到達最後一個點，就繼續移動
        if (currentWaypointIndex < waypoints.Length)
        {
            // 使用 Vector3.MoveTowards 朝向下一個陣列點移動
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], speed * Time.deltaTime);

            // 如果到達當前目標點，就切換到陣列的下一個點
            if (transform.position == waypoints[currentWaypointIndex])
            {
                currentWaypointIndex++;
            }
        }
    }
}