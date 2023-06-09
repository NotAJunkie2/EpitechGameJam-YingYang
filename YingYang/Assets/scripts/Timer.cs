using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float remainingDuration;
    private bool pause = false;

    public float durationSeconds;
    public Image uiFill;
    // Start is called before the first frame update
    void Start()
    {
        Begin(this.durationSeconds);
    }

    void Begin(float seconds)
    {
        this.remainingDuration = seconds;
        StartCoroutine(this.updateTimer());
    }

    private IEnumerator updateTimer()
    {
        while (this.remainingDuration >= 0) {
            if (!this.pause) {
                uiFill.fillAmount = Mathf.InverseLerp(0, this.durationSeconds, this.remainingDuration);
                remainingDuration -= 0.100f;
                yield return new WaitForSeconds(0.100f);
            }
            yield return null;
        }
        OnEnd();
    }

    void setPause(bool pause)
    {
        this.pause = pause;
    }

    public void resume()
    {
        this.pause = false;
        StartCoroutine(this.updateTimer());
    }

    private void OnEnd()
    {
        // do something
        SceneManager.LoadScene("Game Over");
        return;
    }
}
