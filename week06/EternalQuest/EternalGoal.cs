public class EternalGoal : Goal {
    public EternalGoal(string name, string description, int points) : base(name, description, points) {}

    public override int RecordEvent() {
        return _points;
    }

    public override bool IsComplete() {
        return false;
    }

    public override string GetStringRepresentation() {
        string payload = $"1{_shortName.Length:X8}{_shortName}{_description.Length:X8}{_description}{_points:X8}";
        return $"{payload.Length:X16}{payload}";
    }
}