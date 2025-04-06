using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BoardManager m_Board;
    private Vector2Int m_CellPosition;

    public Vector2Int GetCurrentPosition()
    {
        return m_CellPosition;
    }

    public void Spawn(BoardManager boardManager, Vector2Int cell)
    {
        m_Board = boardManager;
        MoveTo(cell);
    }
    
    public void MoveTo(Vector2Int cell)
    {
        m_CellPosition = cell;
        transform.position = m_Board.CellToWorld(m_CellPosition);
    }

    public string MoveUp()
    {
        Vector2Int newCellTarget = m_CellPosition;
        newCellTarget.y += 1;

        BoardManager.CellData cellData = m_Board.GetCellData(newCellTarget);
        if (cellData != null && cellData.Passable)
        {
            MoveTo(newCellTarget);
            m_Board.Log();
            if (CheckClear(newCellTarget))
            {
                return "Stage Clear";
            }
            else
            {
                return "Move Up";
            }
        }
        else
        {
            return "Invalid Move";
        }
    }

    public string MoveDown()
    {
        Vector2Int newCellTarget = m_CellPosition;
        newCellTarget.y -= 1;

        BoardManager.CellData cellData = m_Board.GetCellData(newCellTarget);
        if (cellData != null && cellData.Passable)
        {
            MoveTo(newCellTarget);
            m_Board.Log();
            if (CheckClear(newCellTarget))
            {
                return "Stage Clear";
            }
            else
            {
                return "Move Down";
            }
        }
        else
        {
            return "Invalid Move";
        }
    }
    public string MoveRight()
    {
        Vector2Int newCellTarget = m_CellPosition;
        newCellTarget.x += 1;

        BoardManager.CellData cellData = m_Board.GetCellData(newCellTarget);
        if (cellData != null && cellData.Passable)
        {
            MoveTo(newCellTarget);
            m_Board.Log();
            if (CheckClear(newCellTarget))
            {
                return "Stage Clear";
            }
            else
            {
                return "Move Right";
            }
        }
        else
        {
            return "Invalid Move";
        }
    }

    public string MoveLeft()
    {
        Vector2Int newCellTarget = m_CellPosition;
        newCellTarget.x -= 1;

        BoardManager.CellData cellData = m_Board.GetCellData(newCellTarget);
        if (cellData != null && cellData.Passable)
        {
            MoveTo(newCellTarget);
            m_Board.Log();
            if (CheckClear(newCellTarget))
            {
                return "Stage Clear";
            }
            else
            {
                return "Move Left";
            }
        }
        else
        {
            return "Invalid Move";
        }
    }

    private bool CheckClear(Vector2Int cell)
    {
        return cell == new Vector2Int(6, 6);
    }

    
    private void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            MoveUp();
        }
        else if(Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            MoveDown();
        }
        else if(Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            MoveRight();
        }
        else if(Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            MoveLeft();
        }
    }
}