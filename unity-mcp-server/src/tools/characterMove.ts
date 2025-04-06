import { MCPTool } from "mcp-framework";
import { z } from "zod";
import * as UnityConnection from "../unity/unityConnection.js";

interface CharacterMoveInput {
  direction: string;
}

class CharacterMoveTool extends MCPTool<CharacterMoveInput> {
  name = "character_move_tool";
  description = "Move character in a direction. Use 'up', 'down', 'left', 'right'. Map info: 9 walls, 0 walkable ground, 1 player position, and 5 exit. Player can't move through walls. Player can win if they reach the exit.";

  schema = {
    direction: {
      type: z.string(),
      description: "Direction to move the character. Use 'up', 'down', 'left', 'right'",
    }
  };

  async execute(input: CharacterMoveInput) {
    return await UnityConnection.sendToUnity(JSON.stringify({
      name: this.name,
      format: JSON.stringify(input)
    }));
  }
}

export default CharacterMoveTool;