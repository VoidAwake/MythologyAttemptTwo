using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetup : MonoBehaviour
{
    public GameObject black, white;
    public Texture2D[] maps;
    public string[] mapNames;
    public Transform topRight;
    // Start is called before the first frame update
    void Start()
    {
        Create();
    }
    string Create()
    {
        int i = Random.Range(0, maps.Length);

        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 40; y++)
            {
                if (maps[i].GetPixel(x, y) == Color.black) LevelManager.maxScore++;
                Instantiate(maps[i].GetPixel(x, y) == Color.black ? black : white, new Vector2(topRight.position.x + x * 0.25f, topRight.position.y + y * 0.25f), Quaternion.identity, transform);
            }
        }
        LevelManager.maxScore = Mathf.RoundToInt(LevelManager.maxScore * 0.6f);
        return mapNames[i];
    }
    // Update is called once per frame
    public string Reset()
    {
        foreach (var item in GetComponentsInChildren<SpriteRenderer>())
        {
            //check value
            Destroy(item.gameObject);
        }
        return Create();
    }
}
