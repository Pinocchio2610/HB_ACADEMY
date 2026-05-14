using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    void Update()
    {
        // Lấy tọa độ chuột trong thế giới
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z;
        // Giới hạn camera trong biên
        float clampX = Mathf.Clamp(mouseWorldPos.x, minPosition.x, maxPosition.x);
        float clampY = Mathf.Clamp(mouseWorldPos.y, minPosition.y, maxPosition.y);
        Vector3 targetPos = new Vector3(clampX, clampY, mouseWorldPos.z);
        // Di chuyển mượt
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
