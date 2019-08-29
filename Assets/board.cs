using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    public GameObject OnHand;
    private BackgroundTile[,] allTiles;
    private int[,] tileMap;

    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        tileMap = new int[width, height];
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                tileMap[i, j] = 0;
            }
        }
        SetUp();
    }

    private void SetUp()
    {
        for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity);
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "{" + i + "," + j + "}";
            }
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < OnHand.transform.childCount; i++)
            {
                bool canPlaced = true;

                for(int j=0; j< OnHand.transform.GetChild(i).childCount; j++)
                {
                    Vector3 here = OnHand.transform.GetChild(i).GetChild(j).position;
                    here.x = Mathf.Round(here.x);
                    here.y = Mathf.Round(here.y);
                    here.z = 0;
                    if(here.x < 0 || here.x >= width || here.y < 0 || here.y >= height)
                    {
                        canPlaced = false;
                        break;
                    }
                    else if(tileMap[(int)here.x, (int)here.y] == 1)
                    {
                        canPlaced = false;
                        break;
                    }
                }

                if (canPlaced)
                {
                    for (int j = 0; j < OnHand.transform.GetChild(i).childCount; j++)
                    {
                        Vector3 here = OnHand.transform.GetChild(i).GetChild(j).position;
                        here.x = Mathf.Round(here.x);
                        here.y = Mathf.Round(here.y);
                        here.z = 0;
                        GameObject bimlo = Instantiate(OnHand.transform.GetChild(i).GetChild(j).gameObject, here, Quaternion.identity);
                        bimlo.transform.parent = this.transform;
                        Destroy(OnHand.transform.GetChild(i).GetChild(j).gameObject);
                        tileMap[(int)here.x, (int)here.y] = 1;
                        Debug.Log("Placed");
                    }
                }
            }
        }
    }
}
