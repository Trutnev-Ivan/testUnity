using UnityEngine.Events;

public class Statistics
{
    public static UnityAction<int> OnChangeScore;
    
    public static int Score
    {
        get;
        private set;
    }

    public static void incrementScore()
    {
        Score++;
        OnChangeScore.Invoke(Score);
    }
}