using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MathGate : MonoBehaviour
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

    void Start()
    {
        GenerateQuestion();
        AssignAnswers();
        SwapBlockPositions();
    }

    void GenerateQuestion()
    {
        // Generate random operands and operation
        int operandA = Random.Range(1, 11);
        int operandB = Random.Range(1, 11);
       /* char operation = Random.Range(0, 3) switch
        {
            0 => '+',
            1 => '-',
            _ => '*',
        };*/
       char operation = '+';

        // Display the math question
        questionText.GetComponent<TextMeshPro>().text = $"{operandA} {operation} {operandB} = ?";
    }

    void AssignAnswers()
    {
        // Calculate correct answer
        int operandA = int.Parse(questionText.GetComponent<TextMeshPro>().text.Split(' ')[0]);
        int operandB = int.Parse(questionText.GetComponent<TextMeshPro>().text.Split(' ')[2]);
        int correctAnswer = operandA + operandB;

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
        int wrongAnswer = correctAnswer + Random.Range(-11, 10);
        if (wrongAnswer == correctAnswer)
        {
            wrongAnswer += 1;
        }
       wrongBlockText1.GetComponent<TextMeshPro>().text = wrongAnswer.ToString();
        int wrongAnswer2 = correctAnswer + Random.Range(-8, 9);
        if (wrongAnswer2 == correctAnswer)
        {
            wrongAnswer2 += 1;
        }
       wrongBlockText2.GetComponent<TextMeshPro>().text = wrongAnswer2.ToString();
    }

    void SwapBlockPositions()
    {
        // Randomly select one of the wrong blocks
        Transform selectedWrongBlock = wrongBlocks[Random.Range(0,wrongBlocks.Length)];

        // Swap positions of the correct block with the selected wrong block
        Vector3 tempPosition = correctBlock.position;
        correctBlock.position = selectedWrongBlock.position;
        selectedWrongBlock.position = tempPosition;
    }
}
