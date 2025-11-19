using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    public int width = 6;
    public int height = 12;
    public float cellSize = 1f;
    public Color gridColor = new Color(0.5f, 0.5f, 0.5f, 0.3f);

    private LineRenderer lineRenderer;

    void Start()
    {
        DrawVisibleGrid();
    }

    void DrawVisibleGrid()
    {
        // 親オブジェクトの作成
        GameObject gridLines = new GameObject("GridLines");
        gridLines.transform.parent = transform;

        // 縦線を描画
        for (int x = 0; x <= width; x++)
        {
            CreateLine(
                gridLines.transform,
                new Vector3(x * cellSize, 0, 0),
                new Vector3(x * cellSize, height * cellSize, 0),
                $"VerticalLine_{x}"
            );
        }

        // 横線を描画
        for (int y = 0; y <= height; y++)
        {
            CreateLine(
                gridLines.transform,
                new Vector3(0, y * cellSize, 0),
                new Vector3(width * cellSize, y * cellSize, 0),
                $"HorizontalLine_{y}"
            );
        }
    }

    void CreateLine(Transform parent, Vector3 start, Vector3 end, string name)
    {
        GameObject lineObj = new GameObject(name);
        lineObj.transform.parent = parent;

        LineRenderer lr = lineObj.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.startWidth = 0.02f;
        lr.endWidth = 0.02f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = gridColor;
        lr.endColor = gridColor;
        lr.sortingOrder = -1;  //グリッドを背景に
    }
}
