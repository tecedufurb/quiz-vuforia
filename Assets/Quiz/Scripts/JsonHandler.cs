using System.Collections.Generic;

public class JsonHandler {

	public List<Quiz> quizzes;

	public static JsonHandler CreateFromJSON(string jsonString) {
        return UnityEngine.JsonUtility.FromJson<JsonHandler>(jsonString);
    }

}
