using System.Collections.Generic;
using UnityEngine;

public class QuizController {

	private const string JSON_PATH = "Quiz/quizzesList";
	private readonly Quiz quiz;
	private int questionIndex;

	public Question GetQuestion () {
		return quiz.questions[questionIndex];
	}

	public QuizController () {
		string jsonString = Resources.Load(JSON_PATH).ToString();
		JsonHandler json = JsonHandler.CreateFromJSON(jsonString);
		quiz = json.quiz;
	}

	private void ResetQuestion () {
		questionIndex = 0;
	}

	public Question GetRandomQuestion () {
		if (IsQuestionListEmpty()) {
			Debug.Log("Cabo as perguntas");
		}

		int index = Random.Range(0, quiz.questions.Count);
		questionIndex = Random.Range(0, quiz.questions.Count);
		return quiz.questions[questionIndex];
	}

	public bool IsAnswerRight (int alternative) {
		return alternative == quiz.questions[questionIndex].answer;
	}

	public bool IsQuestionListEmpty () {
		return quiz.questions.Count == 0;
	}

	// public void RightAnswer () {
	// 	RemoveQuestion(quiz.questions[questionIndex]);
	// 	GetRandomQuestion();
	// }

	// public void WrongAnswer () {
	// 	GetRandomQuestion();
	// }

	public void RemoveQuestion (Question questionR) {
		quiz.questions.Remove(questionR);
	}
}
