using UnityEngine;

public class ImageTargetQuizHandler : DefaultTrackableEventHandler {


	public static bool isPlaying = true;
	[SerializeField] private GameObject questionsPanel;
	[SerializeField] private GameManager game;
	[SerializeField] private AudioManager audio;

	protected override void Start() {
        base.Start();
		isPlaying = true;
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

	protected override void OnTrackingFound() {
		base.OnTrackingFound();
		if (isPlaying) {
			game.NextQuestion();
			questionsPanel.SetActive(true);
			audio.PlayQuestionAudio(game.GetQuestion().id);
		}
	}

	protected override void OnTrackingLost() {
		base.OnTrackingLost();
		if (isPlaying) {
			questionsPanel.SetActive(false);
			game.ResetScreen();
			audio.StopAudio();
		}
	}

}
