using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] audios;

    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip RightAnswerAudio;
    [SerializeField] private AudioClip WrongAnswerAudio;
    [SerializeField] private AudioClip WinGameAudio;

    public void PlayQuestionAudio(int idQuestion) {
        AudioSource.clip = audios[idQuestion];
        AudioSource.Play();
    }

    public void PlayRightAnswerAudio() {
        AudioSource.clip = RightAnswerAudio;
        AudioSource.Play();
    }

    public void PlayWrongAnswerAudio() {
        AudioSource.clip = WrongAnswerAudio;
        AudioSource.Play();
    }

    public void PlayWinAudio() {
        AudioSource.clip = WinGameAudio;
        AudioSource.Play();
    }

    public void StopAudio() {
        AudioSource.Stop();
    }
}
