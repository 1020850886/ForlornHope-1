using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {
 private static GameObject manager;

    private void Awake()
    {
        manager = gameObject;
    }

    public static Vector2 MapToAbsolute(Vector2 mapPosition)
    {
        Vector2 AbsolutePosition = new Vector2();
        //右下为x轴正方向，左下为y轴正方向
        mapPosition /= manager.transform.localScale;
        AbsolutePosition.x = (mapPosition.x - mapPosition.y) * 0.5f;
        AbsolutePosition.y = -(mapPosition.x + mapPosition.y) * 0.25f;
        AbsolutePosition += (Vector2)manager.transform.position;
        return AbsolutePosition;
    }
    public static Vector2 AbsoluteToMap(Vector2 AbsolutePosition)
    {
        AbsolutePosition -= (Vector2)manager.transform.position;
        Vector2 mapPosition = new Vector2();
        //右下为x轴正方向，左下为y轴正方向
        mapPosition.x = (AbsolutePosition.x / 0.5f - AbsolutePosition.y / 0.25f) / 2;
        mapPosition.y = (AbsolutePosition.x * 0.5f + AbsolutePosition.y * 0.25f) / 2;
        mapPosition *= manager.transform.localScale;
        return mapPosition;
    }
}
