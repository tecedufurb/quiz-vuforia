using System.Collections.Generic;

public class JsonHandler {

	public Quiz quiz;

	public static JsonHandler CreateFromJSON(string jsonString) {
        return UnityEngine.JsonUtility.FromJson<JsonHandler>(jsonString);
    }

}
