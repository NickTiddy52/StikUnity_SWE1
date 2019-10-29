using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProcedureGeneration : MonoBehaviour
{
    public int width;
    public int height;
    public Tilemap tilemap;
    public Tile tile;
    public Tile top;
    public Tile hillLeft;
    public Tile hillRight;
    public GameObject[] obj = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Map
        int[,] map  = new int[width,height];
        //Use Noise to generate map
        map = RandomWalkTopSmoothed(map, Random.Range(0f, 1f), 3);
        RenderMap(map, tilemap, tile,top,hillLeft, hillRight);
        RenderObstacles(map, obj);
    }

    public static void RenderObstacles(int[,] map, GameObject[] obj)
    {
        float spawnX = 0;
        float spawny = 0;
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            spawnX = x;
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                 spawny = y + 4f;
                if(map[x,y] == 1)
                {
                    if (map[x, y + 1] == 0)
                    {
                        int rand = Random.Range(0, 50);
                        if(rand == 10 || rand == 20)
                        {
                            Instantiate(obj[2], new Vector3(spawnX, spawny + 10, 0), Quaternion.Euler(0,0,90));
                        }
                        if(rand == 3)
                        {
                            Instantiate(obj[1], new Vector3(spawnX, spawny, 0), Quaternion.identity);

                        }
                        if (rand == 2)
                        {
                            rand = Random.Range(2, 4);
                            for (int i = 0; i < rand; i++) 
                            {
                                Instantiate(obj[0], new Vector3(spawnX, spawny, 0), Quaternion.identity);
                                Debug.Log("Random Val: " + rand);
                                spawny += 4;
                            }
                            

                        }

                    }
                }

            }
        }
            }
    public static void RenderMap(int[,] map, Tilemap tilemap, TileBase tile, TileBase top, TileBase hillLeft, TileBase hillRight)
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (map[x, y] == 1)
                {
                    if (x > 0 && map[x - 1, y] == 0 && map[x, y + 1] == 0)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), hillLeft);
                    }
                    else if (x < map.Length && map[x+1,y] == 0 && map[x,y+1] == 0)
                    {
                         tilemap.SetTile(new Vector3Int(x, y, 0), hillRight);

                    }
                    else if (map[x, y+1] == 0)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), top);

                    }
                    else
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), tile);

                    }
                }
            }
        }
    }

    
    public static int[,] RandomWalkTopSmoothed(int[,] map, float seed, int minSectionWidth)
    {
        //Seed our random
        System.Random rand = new System.Random(seed.GetHashCode());

        //Determine the start position
        int lastHeight = Random.Range(0, map.GetUpperBound(1));

        //Used to determine which direction to go
        int nextMove = 0;
        //Used to keep track of the current sections width
        int sectionWidth = 0;

        //Work through the array width
        for (int x = 0; x <= map.GetUpperBound(0); x++)
        {
            //Determine the next move
            nextMove = rand.Next(2);

            //Only change the height if we have used the current height more than the minimum required section width
            if (nextMove == 0 && lastHeight > 0 && sectionWidth > minSectionWidth)
            {
                lastHeight--;
                sectionWidth = 0;
            }
            else if (nextMove == 1 && lastHeight < map.GetUpperBound(1) && sectionWidth > minSectionWidth)
            {
                lastHeight++;
                sectionWidth = 0;
            }
            //Increment the section width
            sectionWidth++;

            //Work our way from the height down to 0
            for (int y = lastHeight; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }

        //Return the modified map
        return map;
    }



}

