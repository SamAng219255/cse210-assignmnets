public class FailableGoal : Goal {
    private bool _isComplete;
    private int _penalty;

    public FailableGoal(string name, string description, int points, int penalty) : base(name, description, points) {
        _isComplete = false;
        _penalty = penalty;
    }

    public override int RecordEvent() {
        Console.Write("Did you make your goal? (Y/n) ");
        string confirmation = Console.ReadLine();
        if(confirmation == "y" || confirmation == "Y") {
            _isComplete = true;
            return _points;
        }
        else if(confirmation == "n" || confirmation == "N") {
            _isComplete = true;
            return -_penalty;
        }
        else {
            Console.WriteLine("Invalid response.");
            return 0;
        }
    }

    public void MarkComplete() {
        _isComplete = true;
    }

    public override bool IsComplete() {
        return _isComplete;
    }

    public override string GetDetailsString() {
        string completeMark = IsComplete() ? "X" : " ";
        return $"[{completeMark}] {_shortName} ({_points} pts) — {_description} ({_penalty} pt penalty if not accomplished)";
    }

    public override string GetStringRepresentation() {
        string completeData = _isComplete ? "1" : "0";
        string payload = $"4{_shortName.Length:X8}{_shortName}{_description.Length:X8}{_description}{_points:X8}{completeData}{_penalty:X8}";
        return $"{payload.Length:X16}{payload}";
    }
}