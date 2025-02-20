using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float swipeThreshold = 50f; // Ngưỡng vuốt tối thiểu (pixel)
    [SerializeField] private GameObject brickNormal;

    private Vector2 startTouchPosition; // Vị trí bắt đầu vuốt
    private Vector2 endTouchPosition;   // Vị trí kết thúc vuốt

    private Vector2Int moveDirection;      // Hướng di chuyển
    private Vector2Int playerPos; // Vị trí hiện tại trong ma

    private bool isMoving;
    
    public static Character character { get; private set; } //Singleton

   
    private void Awake()
    {
        if (character == null)
        {
            character = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        while (isMoving)
        {
            Moving(moveDirection);
        }

        DetectSwipe();
    }

    internal void OnInit()
    {
        isMoving = false;
    }

    private void DetectSwipe()
    {
        // Bắt đầu vuốt
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
        }

        // Kết thúc vuốt
        if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            Vector2 deltaSwipe = endTouchPosition - startTouchPosition;

            if (deltaSwipe.magnitude >= swipeThreshold)
            {
                FindSwipeDirection(deltaSwipe);
            }
        }
    }

    private void FindSwipeDirection(Vector2 deltaSwipe)
    {
        // Xác định hướng vuốt
        if (Mathf.Abs(deltaSwipe.x) > Mathf.Abs(deltaSwipe.y)) // Vuốt ngang
        {
            if (deltaSwipe.x > 0)
            {
                moveDirection = Vector2Int.right; // Vuốt sang phải
            }
            else
            {
                moveDirection = Vector2Int.left; // Vuốt sang trái
            }
        }
        else // Vuốt dọc
        {
            if (deltaSwipe.y > 0)
            {
                moveDirection = Vector2Int.up; // Vuốt lên
            }
            else
            {
                moveDirection = Vector2Int.down; // Vuốt xuống
            }
        }
        playerPos = new Vector2Int((int)transform.position.x, (int)transform.position.z);
        isMoving = true;
       
    }

    private void Moving(Vector2Int direction)
    {
        Vector2Int newPos = playerPos;
        Vector2Int nextPos = newPos + direction;

        if (IsValidMove(nextPos))
        {
            newPos = nextPos;

            // Cập nhật vị trí mới
            playerPos = newPos;
            transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.y);
            CheckBrick();
        }
        else
        {
            isMoving = false;
        }
    }

    private bool IsValidMove(Vector2Int pos)
    {
        // Kiểm tra vị trí trong phạm vi và không phải ô không hợp lệ
        int tileValue = MapManager.mapManager.GetTileValue(pos.x, pos.y);
        return tileValue > 0;
    }

    private void CheckBrick()
    {
        int tileValue = MapManager.mapManager.GetTileValue(playerPos.x, playerPos.y);

        if (tileValue == 2) // Ô thêm gạch
        {
            AddBrick();
        }
        else if (tileValue == 3) // Ô trừ gạch
        {
            RemoveBrick();
        }
        else if (tileValue == 4) // Ô đích => win
        {
            OnWinning();
        }
    }

    private void OnWinning()
    {
        ClearBricks();
        UIManager.uiManager.ShowGameUI();
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
    }

    private void AddBrick()
    {
        GameObject brick = GetBrickAtPosition(transform.position);
        if (brick != null)
        {
            transform.position += new Vector3(0, 0.1f, 0); // Kéo toàn bộ lên với khoảng cách = 1 viên gạch
            brick.transform.SetParent(transform); // Gán parent là nhân vật 
            float brickoffset = -1 - transform.childCount * 0.1f;
            brick.transform.localPosition = new Vector3(0, brickoffset, 0); // Xếp chồng dưới chân nhân vật
        }
    }

    private void RemoveBrick()
    {
        if (transform.childCount > 0)
        {
            transform.position -= new Vector3(0, 0.1f, 0);
            Transform lastBrick = transform.GetChild(transform.childCount - 1);
            lastBrick.transform.SetParent(null);
            Destroy(lastBrick.gameObject);
        }
        else //Thua
        {
            UIManager.uiManager.GameOver();
            isMoving = false;
        }
    }

    private void ClearBricks()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private GameObject GetBrickAtPosition(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity))
        {
            return hit.collider.gameObject; // Trả về đối tượng trúng tia ray
        }
        return null; // Không trúng gì
    }
}