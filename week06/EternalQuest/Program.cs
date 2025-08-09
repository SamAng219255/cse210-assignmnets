using System;

/*
I added three additional additional types of goals.
Anti-Goals, or Obstacles, represent bad habits to avoid and function like Eternal Goals, except they subtract their value from your total instead.
Failable Goals represent tasks that you might fail and ask you when you record them if you succeeded. It also has an optional penalty if you fail the goal. (For instance, if your goal was to finish your homework assignment on time.)
Progress Goals are similar to Checklist Goals, but you might be making more or less progress each time you record it so it asks you how much progress you made when you record it.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new();

        manager.Start();
    }
}