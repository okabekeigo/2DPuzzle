using UnityEngine;

public class Board : MonoBehaviour
{
    public int width = 6;
    public int height = 12;
    public float cellSize = 1f;

    // グリッドのデータ（null = 空、GameObject = ブロック）
    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[width, height];
        DrawGrid();
    }

    // グリッドの線を描画（デバッグ用）
    void DrawGrid()
    {
        // 縦線
        for (int x = 0; x <= width; x++)
        {
            Debug.DrawLine(
                new Vector3(x * cellSize, 0, 0),
                new Vector3(x * cellSize, height * cellSize, 0),
                Color.white,
                100f
            );
        }

        // 横線
        for (int y = 0; y <= height; y++)
        {
            Debug.DrawLine(
                new Vector3(0, y * cellSize, 0),
                new Vector3(width * cellSize, y * cellSize, 0),
                Color.white,
                100f
            );
        }
    }

    // グリッド座標がボード内かチェック
    public bool IsInsideBoard(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    // 指定座標が空いているかチェック
    public bool IsEmpty(int x, int y)
    {
        if (!IsInsideBoard(x, y)) return false;
        return grid[x, y] == null;
    }
}
