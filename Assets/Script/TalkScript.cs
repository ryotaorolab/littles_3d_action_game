using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkScript : MonoBehaviour
{
    [SerializeField]
    Text dialogueText;
    public string[] sentences;
    private int index;
    [SerializeField]
    float typingSpeed;

    [SerializeField]
    bool TouchSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 外部から会話機能を呼び出しを行う場合の処理
    public void TalkStart(string[] Talksentences)
    {
        sentences = Talksentences;
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText.text == sentences[index])
        {
            if(Input.GetMouseButtonDown(0))
            {
                NextSentence();
            }
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new
                WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Type());
        } else
        {
            dialogueText.text = "";
        }
    }

    // 触れたときの処理
    private void OnTriggerEnter(Collider collision)
    {
        if(TouchSwitch)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine(Type());
            }
        }
    }
}
