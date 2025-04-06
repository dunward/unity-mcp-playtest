import { MCPTool } from "mcp-framework";
import { z } from "zod";
import * as UnityConnection from "../unity/unityConnection.js";

interface MapControlInput {
  command: string;
}

class MapControlTool extends MCPTool<MapControlInput> {
  name = "map_control_tool";
  description = "Control the map. Use 'reset' to generate new map if current map is impossible to clear, 'get_map_info' to get current map information.";

  schema = {
    command: {
      type: z.string(),
      description: "Command to control the map. Use 'reset', 'get_map_info'",
    }
  };

  async execute(input: MapControlInput) {
    return await UnityConnection.sendToUnity(JSON.stringify({
      name: this.name,
      format: JSON.stringify(input)
    }));
  }
}

export default MapControlTool;