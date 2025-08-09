public class SimpleGoal : Goal {
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points) {
        _isComplete = false;
    }

    public override int RecordEvent() {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() {
        return _isComplete;
    }

    public override string GetStringRepresentation() {
        string completeData = _isComplete ? "1" : "0";
        string payload = $"0{_shortName.Length:X8}{_shortName}{_description.Length:X8}{_description}{_points:X8}{completeData}";
        return $"{payload.Length:X16}{payload}";
    }
}