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
            Debug.LogWarning("AudioSource�� �������� �ʾ� �߰��Ͽ����ϴ�.");
        }

        audioSource.volume = 1.0f;       // ���� �ִ�� ����
        audioSource.mute = false;        // ���Ұ� ����
        audioSource.loop = false;        // �ݺ� ��� ����
        audioSource.playOnAwake = false; // �ڵ� ��� ����

        if (testClip != null)
        {
            audioSource.clip = testClip;
            audioSource.Play();
            Debug.Log("���� �׽�Ʈ ����: " + testClip.name);
        }
        else
        {
            Debug.LogError("�׽�Ʈ Ŭ���� �����ϴ�!");
        }
    }
}
