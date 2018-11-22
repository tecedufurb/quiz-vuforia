using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip RightAnswerAudio;
    [SerializeField] private AudioClip WrongAnswerAudio;
    [SerializeField] private AudioClip WinGameAudio;

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
}
