using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private QuizController quiz;
	private AudioManager audio;
	private int score;

	// private Color rightAnswerColor = new Color32(85, 255, 85, 255);
	// private Color wrongAnswerColor = new Color32(255, 70, 70, 255);

	private bool answered = false;
	private int rightAnswers;
	private int wrongAnswers;

	private const byte A = 0;
	private const byte B = 1;
	private const byte C = 2;

	[SerializeField] private GameObject questionPanel;
	[SerializeField] private GameObject finalPanel;
	[SerializeField] private Text questionDescription;
	[SerializeField] private Text[] alternatives;
	[SerializeField] private GameObject[] alternativesButtons;
	[SerializeField] private Text rightAnswersText;
	[SerializeField] private Text wrongAnswersText;
	[SerializeField] private Sprite normalColor;
	[SerializeField] private Sprite rightAnswerColor;
	[SerializeField] private Sprite wrongAnswerColor;

	void Start () {
		// quiz = new QuizController();
		NextQuestion();

		audio = FindObjectOfType<AudioManager>();
	}
	
	private void ShowQuestion (Question question) {
		questionDescription.text = question.description;
		alternatives[A].text = question.alternatives[A];
		alternatives[B].text = question.alternatives[B];
		alternatives[C].text = question.alternatives[C];
	}

	public void NextQuestion () {
		quiz.GetRandomQuestion();
		ShowQuestion (quiz.GetQuestion());
	}

	public void Answer (int answer) {
		if(!answered)
			StartCoroutine(AnswerDelay(answer, 3));
	}

	private IEnumerator AnswerDelay (int answer, float delay) {
		answered = true;
		if(quiz.IsAnswerRight(answer)) {
			quiz.RemoveQuestion(quiz.GetQuestion());
			IncreaseScore();

			if(quiz.IsQuestionListEmpty())
				GameOver();
			else
				audio.PlayRightAnswerAudio();
			
			alternativesButtons[answer].GetComponent<Image>().sprite = rightAnswerColor;
			
			yield return new WaitForSeconds(delay);

			alternativesButtons[answer].GetComponent<Image>().color = Color.white;
			questionPanel.SetActive(false);
		} else {
			DecreaseScore();
			audio.PlayWrongAnswerAudio();
			alternativesButtons[answer].GetComponent<Image>().sprite = wrongAnswerColor;

			yield return new WaitForSeconds(delay);

			alternativesButtons[answer].GetComponent<Image>().color = Color.white;
			questionPanel.SetActive(false);
		}
		answered = false;
	}

	private void IncreaseScore () {
		rightAnswers++;
		rightAnswersText.text = rightAnswers.ToString();
	}

	private void DecreaseScore () {
		wrongAnswers++;
		wrongAnswersText.text = wrongAnswers.ToString();
	}

	private void GameOver () {
		ImageTargetQuizHandler.isPlaying = false;
		questionPanel.SetActive(false);
		finalPanel.SetActive(true);
		audio.PlayWinAudio();
	}

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void ResetScreen () {
		StopAllCoroutines();
		answered = false;
		questionPanel.SetActive(false);
		finalPanel.SetActive(false);
		foreach (GameObject button in alternativesButtons) {
			button.GetComponent<Image>().sprite = normalColor;
		}
	}

	public void PlayQuestionSoundAgain () {
		if (!answered)
			audio.PlayQuestionAudio(quiz.GetQuestion().id);
	}

	public Question GetQuestion () {
		return quiz.GetQuestion();
	}

}
