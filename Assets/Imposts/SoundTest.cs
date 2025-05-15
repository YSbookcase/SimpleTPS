using UnityEngine;

public class SoundTest : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip testClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.LogWarning("AudioSource가 존재하지 않아 추가하였습니다.");
        }

        audioSource.volume = 1.0f;       // 볼륨 최대로 설정
        audioSource.mute = false;        // 음소거 해제
        audioSource.loop = false;        // 반복 재생 해제
        audioSource.playOnAwake = false; // 자동 재생 해제

        if (testClip != null)
        {
            audioSource.clip = testClip;
            audioSource.Play();
            Debug.Log("사운드 테스트 시작: " + testClip.name);
        }
        else
        {
            Debug.LogError("테스트 클립이 없습니다!");
        }
    }
}
