using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>{
            new RunningActivity("01 Aug 2025", 10, 0.75),
            new CyclingActivity("02 Aug 2025", 90, 22.3),
            new SwimmingActivity("04 Aug 2025", 30, 24)
        };

        foreach(Activity activity in activities) {
            Console.WriteLine(activity.GetSummary());
        }
    }
}