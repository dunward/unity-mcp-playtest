using UnityEngine;

public static class MapInfoTools
{
    private class MapInfoInput
    {
        public string command;
    }

    public static string Command(string format)
    {
        var input = JsonUtility.FromJson<MapInfoInput>(format);
        var player = GameObject.FindObjectOfType<BoardManager>();

        switch (input.command.ToLower())
        {
            case "reset":
                return player.Reset();
            case "get_map_info":
                return player.Log();
            default:
                return "Invalid command";
        }
    }
}