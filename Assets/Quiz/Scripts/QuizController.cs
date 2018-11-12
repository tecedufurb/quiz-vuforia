using System.Collections.Generic;
using UnityEngine;

public class QuizController {

	private readonly List<Quiz> quizList;
	private int quizIndex;
	private Quiz quiz;

	private const string JSON_PATH = "Quiz/quizzesList";


	public QuizController () {
		string jsonString = Resources.Load(JSON_PATH).ToString();
		JsonHandler json = JsonHandler.CreateFromJSON(jsonString);
		quizList = json.quizzes;
		
		quizIndex = 0;
		quiz = quizList[quizIndex];
	}

	public void NextQuiz () {
		quizIndex = (quizIndex < quizList.Count) ? quizIndex++ : 0;
		quiz = quizList[quizIndex];
	}

	public void PreviousQuiz () {
		quizIndex = (quizIndex > 0) ? quizIndex-- : quizList.Count;
		quiz = quizList[quizIndex];
	}

	public void ShowContent () {
		foreach (Quiz quiz in quizList) {
			foreach(Question question in quiz.questions) {
				Debug.Log(question.description);
			}
		}
	}
}
