using UnityEngine;

public static class CharacterMoveTools
{
    private class MoveInput
    {
        public string direction;
    }

    public static string Move(string format)
    {
        var input = JsonUtility.FromJson<MoveInput>(format);
        var player = GameObject.FindObjectOfType<PlayerController>();

        switch (input.direction.ToLower())
        {
            case "up":
                return player.MoveUp();
            case "down":
                return player.MoveDown();
            case "left":
                return player.MoveLeft();
            case "right":
                return player.MoveRight();
            default:
                return "Invalid direction";
        }
    }
}