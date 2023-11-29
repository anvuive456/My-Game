using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Câu hỏi/tạo câu hỏi")]
public class QuestionBase: ScriptableObject
{

    [TextArea] [SerializeField] private string question;
    [TextArea] [SerializeField] private string ott;
    [TextArea] [SerializeField] private string answer;
    [SerializeField] private int points;


    public string QuestionText => question;
    public string Ott => ott;
    public string Answer => answer;
    public int Points => points;
}