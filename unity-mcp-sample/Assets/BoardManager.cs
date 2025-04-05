using UnityEngine;
using UnityEngine.Tilemaps;


public class BoardManager : MonoBehaviour
{
    public class CellData
    {
        public bool Passable;
    }

    private CellData[,] m_BoardData;

    private Tilemap m_Tilemap;
    private Grid m_Grid;

    public int Width;
    public int Height;
    public Tile[] GroundTiles;
    public Tile[] WallTiles;
    public Tile[] BlockingTiles;

    public Tile clearTile;

    public PlayerController Player;

    private void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();
        m_Grid = GetComponentInChildren<Grid>();

        m_BoardData = new CellData[Width, Height];

        for (int y = 0; y < Height; ++y)
        {
            for(int x = 0; x < Width; ++x)
            {
                Tile tile;
                m_BoardData[x, y] = new CellData();

                if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                {
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                    m_BoardData[x, y].Passable = false;
                }
                else
                {
                    if ((Random.Range(0, 100) < 30) && 
                        !(x == 1 && y == 1) &&
                        !(x == Width - 2 && y == Height - 2))
                    {
                        tile = WallTiles[Random.Range(0, WallTiles.Length)];
                        m_BoardData[x, y].Passable = false;
                    }
                    else if (Random.Range(0, 100) < 10)
                    {
                        tile = BlockingTiles[Random.Range(0, BlockingTiles.Length)];
                        m_BoardData[x, y].Passable = false;
                    }
                    else
                    {
                        tile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                        m_BoardData[x, y].Passable = true;
                    }
                }

                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }

        m_Tilemap.SetTile(new Vector3Int(Width - 2, Height - 2, 0), clearTile);

        Player.Spawn(this, new Vector2Int(1, 1));
    }

    public Vector3 CellToWorld(Vector2Int cellIndex)
    {
        return m_Grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }

    public CellData GetCellData(Vector2Int cellIndex)
    {
        if (cellIndex.x < 0 || cellIndex.x >= Width
            || cellIndex.y < 0 || cellIndex.y >= Height)
        {
            return null;
        }

        return m_BoardData[cellIndex.x, cellIndex.y];
    }

    public void Log()
    {
        int[,] mapData = new int[Height, Width];
        
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                mapData[y,x] = m_BoardData[x,y].Passable ? 0 : 9;
            }
        }
        
        Vector2Int playerPos = Player.GetCurrentPosition();
        mapData[playerPos.y, playerPos.x] = 1;
        
        mapData[Height-2,Width-2] = 5;

        string mapString = "";
        for (int y = Height - 1; y >= 0; y--)
        {
            for (int x = 0; x < Width; x++)
            {
                mapString += mapData[y,x] + " ";
            }
            mapString += "\n";
        }
        Debug.Log(mapString);
    }
}