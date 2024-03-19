using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Linq.Expressions;

public class DivideGate : MonoBehaviour
{
    //public Transform questionText;
    public Transform correctBlock;
    public Transform[] wrongBlocks;
    // public Transform correctBlockText;
    // public Transform[] wrongBlocksText;

    public GameObject questionText;
    public GameObject correctBlockText;
    public GameObject wrongBlockText1;
    public GameObject wrongBlockText2;
    //scoreManager
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        GenerateQuestion();
        AssignAnswers();
        SwapBlockPositions();
    }

    void GenerateQuestion()
    {
        if (scoreManager.score < 20)
        {
            GenerateQuestionWithOperands(1, 5);
        }
        else if (scoreManager.score < 70)
        {
            GenerateQuestionWithOperands(1, 11);
        }
        else if (scoreManager.score < 200)
        {
            GenerateQuestionWithOperands(1, 21);
        }
        else
        {

            GenerateQuestionWithOperands(20, 30);
        }


    }
    void GenerateQuestionWithOperands(int minOperand, int maxOperand)
    {
        // Generate random operands and operation
        int operandA = Random.Range(minOperand, maxOperand + 1);
        int operandB = Random.Range(minOperand, maxOperand + 1);

        if (operandA >= operandB)
        {
            if (operandA / operandB >= 1)
            {
                if(operandA%operandB == 0)
                {
                    float debug = operandA / operandB;
                    Debug.Log("a=" + operandA);
                    Debug.Log("b=" + operandB);
                    Debug.Log(debug);
                    questionText.GetComponent<TextMeshPro>().text = $"{operandA} ÷ {operandB} = ?";
                }
            }
           
        }
        // Display the math question
        questionText.GetComponent<TextMeshPro>().text = $"{operandA} ÷ {operandB} = ?";
    }

    void AssignAnswers()
    {
        // Calculate correct answer
        int operandA = int.Parse(questionText.GetComponent<TextMeshPro>().text.Split(' ')[0]);
        int operandB = int.Parse(questionText.GetComponent<TextMeshPro>().text.Split(' ')[2]);
        int correctAnswer = operandA / operandB;

        /*char operation = Random.Range(0, 3) switch
        {
            0 => '+',
            1 => '-',
            _ => '*',
        };
        switch (operation)
        {
            case '+':
                correctAnswer = operandA + operandB;
                break;
            case '-':
                correctAnswer = operandA - operandB;
                break;
            default:
                correctAnswer = operandA * operandB;
                break;
        }*/


        // Assign correct answer to the text child of the correct block
        //correctBlock.GetChild(0).GetComponent<TextMeshPro>().text = correctAnswer.ToString();
        correctBlockText.GetComponent<TextMeshPro>().text = correctAnswer.ToString();
        //Debug.Log("Text Assigned: " + correctBlockText.GetComponent<TextMeshPro>().text);

        // Generate wrong answers and assign them to the text children of the wrong blocks
        /* foreach (Transform wrongBlock in wrongBlocksText)
         {
             int wrongAnswer = correctAnswer + Random.Range(-5, 6); // Generate a wrong answer near the correct one
             wrongBlock.GetComponent<TextMeshPro>().text = wrongAnswer.ToString();
         }*/
        int wrongAnswer = correctAnswer + Random.Range(-6, 5);
        if (wrongAnswer == correctAnswer)
        {
            wrongAnswer += 1;
        }
        wrongBlockText1.GetComponent<TextMeshPro>().text = wrongAnswer.ToString();
        int wrongAnswer2 = correctAnswer + Random.Range(-6, 5);
        if (wrongAnswer2 == correctAnswer)
        {
            wrongAnswer2 += -1;
        }
        wrongBlockText2.GetComponent<TextMeshPro>().text = wrongAnswer2.ToString();
    }

    void SwapBlockPositions()
    {
        int x = Random.Range(0, 10);
        if (x == 0)
        {
            print("middle correctBlock");
        }
        else
        {
            // Randomly select one of the wrong blocks
            Transform selectedWrongBlock = wrongBlocks[Random.Range(0, wrongBlocks.Length)];

            // Swap positions of the correct block with the selected wrong block
            Vector3 tempPosition = correctBlock.position;
            correctBlock.position = selectedWrongBlock.position;
            selectedWrongBlock.position = tempPosition;
        }

    }
}
