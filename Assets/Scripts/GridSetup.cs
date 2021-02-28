﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetup : MonoBehaviour
{
    public GameObject black, white;
    public Texture2D[] maps;
    public Transform topRight;
    // Start is called before the first frame update
    void Start()
    {
        Create();
    }
    void Create()
    {
        int i = Random.Range(0, maps.Length);

        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 40; y++)
            {
                Instantiate(maps[i].GetPixel(x, y) == Color.black ? black : white, new Vector2(topRight.position.x + x * 0.25f, topRight.position.y + y * 0.25f), Quaternion.identity, transform);
            }
        }
    }
    // Update is called once per frame
    public void Reset()
    {
        foreach (var item in GetComponentsInChildren<SpriteRenderer>())
        {
            Destroy(item.gameObject);
        }
        Create();
    }
}
