using System;
using System.IO;
using System.Collections.Generic;

public class GoalManager {
    private List<Goal> _goals;
    private int _score;

    public GoalManager() {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start() {
        bool running = true;
        bool needsSave = false;
        while(running) {
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.Write("Select a choice from the menu: ");
            switch(Console.ReadLine()) {
                case "1":
                    CreateGoal();
                    needsSave = true;
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    needsSave = false;
                    break;
                case "4":
                    LoadGoals();
                    needsSave = false;
                    break;
                case "5":
                    RecordEvent();
                    needsSave = true;
                    break;
                case "6":
                    if(needsSave) {
                        Console.Write("You have unsaved data. Are you sure you wish to quit? (Y/n) ");
                        string confirmation = Console.ReadLine();
                        if(confirmation == "y" || confirmation == "Y") {
                            
                        }
                        else if(confirmation == "n" || confirmation == "N") {
                            Console.WriteLine("Returning to menu.");
                            break;
                        }
                        else {
                            Console.WriteLine("Invalid input. Returning to menu.");
                            break;
                        }
                    }
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid menu option.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo() {
        Console.WriteLine($"Current Score: {_score} pts");
    }

    public void ListGoalNames() {
        Console.WriteLine("Current Goals:");
        int oneBaseInd = 1;
        foreach(Goal goal in _goals) {
            Console.WriteLine($"\t{oneBaseInd++}. {goal.GetNameString()}");
        }
    }

    public void ListGoalDetails() {
        Console.WriteLine("Current Goals:");
        int oneBaseInd = 1;
        foreach(Goal goal in _goals) {
            Console.WriteLine($"\t{oneBaseInd++}. {goal.GetDetailsString()}");
        }
    }

    public void CreateGoal() {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("\t1. Simple Goal");
        Console.WriteLine("\t2. Eternal Goal");
        Console.WriteLine("\t3. Checklist Goal");
        Console.WriteLine("\t4. Obstacle to Avoid");
        Console.WriteLine("\t5. Failable Goal");
        Console.WriteLine("\t6. Progress Goal");
        Console.Write("Which type of goal would you like to create? ");
        string response = Console.ReadLine();
        if(response != "1" && response != "2" && response != "3" && response != "4" && response != "5" && response != "6") {
            Console.WriteLine("Invalid response.");
            return;
        }
        Console.Write("What is the name of the goal? ");
        string shortName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("How many points is this goal worth? ");
        int points;
        if(!int.TryParse(Console.ReadLine(), out points)) {
            Console.WriteLine("Invalid response. Not a number.");
            return;
        }

        switch(response) {
            case "1":
                _goals.Add(new SimpleGoal(shortName, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(shortName, description, points));
                break;
            case "3":
                int checklistTarget;
                int checklistBonus;
                Console.Write("How many events does this goal need in order to be completed? ");
                if(!int.TryParse(Console.ReadLine(), out checklistTarget)) {
                    Console.WriteLine("Invalid response. Not a number.");
                    return;
                }
                Console.Write("How many points should the bonus give? ");
                if(!int.TryParse(Console.ReadLine(), out checklistBonus)) {
                    Console.WriteLine("Invalid response. Not a number.");
                    return;
                }
                _goals.Add(new ChecklistGoal(shortName, description, points, checklistTarget, checklistBonus));
                break;
            case "4":
                _goals.Add(new AntiGoal(shortName, description, Math.Abs(points)));
                break;
            case "5":
                int penalty;
                Console.Write("How many points do you lose for failing this goal? (It's okay if it's zero!) ");
                if(!int.TryParse(Console.ReadLine(), out penalty)) {
                    Console.WriteLine("Invalid response. Not a number.");
                    return;
                }
                _goals.Add(new FailableGoal(shortName, description, points, Math.Abs(penalty)));
                break;
            case "6":
                int progressTarget;
                int progressBonus;
                Console.Write("How many steps does this goal need in order to be completed? ");
                if(!int.TryParse(Console.ReadLine(), out progressTarget)) {
                    Console.WriteLine("Invalid response. Not a number.");
                    return;
                }
                Console.Write("How many points should the bonus give? ");
                if(!int.TryParse(Console.ReadLine(), out progressBonus)) {
                    Console.WriteLine("Invalid response. Not a number.");
                    return;
                }
                _goals.Add(new ProgressGoal(shortName, description, points, progressTarget, progressBonus));
                break;
        }
        Console.WriteLine("Goal successfully created.");
    }

    public void RecordEvent() {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalId;
        if(int.TryParse(Console.ReadLine(), out goalId)) {
            Console.WriteLine("");
            if(goalId <= _goals.Count()) {
                if(goalId > 0) {
                    goalId--;
                    if(_goals[goalId].IsComplete()) {
                        Console.WriteLine("That goal is already complete.");
                    }
                    else {
                        int points = _goals[goalId].RecordEvent();
                        if(points > 0) {
                            Console.WriteLine($"Congratulations on completing your goal!\nYou earned {points} points!");
                        }
                        else if(points < 0) {
                            Console.WriteLine($"It's alright. I know you'll do better next time!\nYou lost {-points} points.");
                        }
                        _score += points;
                    }
                }
                else {
                    Console.WriteLine("That's not a valid option. Please enter the number corresponding to the goal.");
                }
            }
            else {
                Console.WriteLine("That's not a valid option. That number is too high.");
            }
        }
        else {
            Console.WriteLine("\nThat's not a valid option. Please enter the number corresponding to the goal.");
        }
    }

    public void SaveGoals() {
        Console.WriteLine("Please enter the name of the file to save to.");
        string saveFileName = Console.ReadLine();
        using(StreamWriter saveFile = new StreamWriter(saveFileName)) {
            saveFile.Write($"{_score:X8}");
            foreach(Goal goal in _goals) {
                saveFile.Write(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals() {
        Console.WriteLine("Please enter the name of the file to load from.");
        string saveFileName = Console.ReadLine();
        string contents;
        using(StreamReader saveFile = new StreamReader(saveFileName)) {
            contents = saveFile.ReadToEnd();
        }
        int mainInd = 0;
        _score = readInt(contents, 8, ref mainInd);
        _goals = new List<Goal>();
        while(mainInd < contents.Length) {
            int size = readInt(contents, 16, ref mainInd);
            string goalStr = readString(contents, size, ref mainInd);
            
            int goalInd = 0;

            int goalType = readInt(goalStr, 1, ref goalInd);

            int shortNameLength = readInt(goalStr, 8, ref goalInd);
            string shortName = readString(goalStr, shortNameLength, ref goalInd);
            int descriptionLength = readInt(goalStr, 8, ref goalInd);
            string description = readString(goalStr, descriptionLength, ref goalInd);
            int points = readInt(goalStr, 8, ref goalInd);

            if(goalType == 0) {
                int isComplete = readInt(goalStr, 1, ref goalInd);

                SimpleGoal goal = new SimpleGoal(shortName, description, points);

                if(isComplete == 1) {
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }
            else if(goalType == 1) {
                EternalGoal goal = new EternalGoal(shortName, description, points);
                _goals.Add(goal);
            }
            else if(goalType == 2) {
                int amountCompleted = readInt(goalStr, 8, ref goalInd);
                int target = readInt(goalStr, 8, ref goalInd);
                int bonus = readInt(goalStr, 8, ref goalInd);

                ChecklistGoal goal = new ChecklistGoal(shortName, description, points, target, bonus);

                for(int i = 0; i < amountCompleted; i++) {
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }
            else if(goalType == 3) {
                AntiGoal goal = new AntiGoal(shortName, description, points);
                _goals.Add(goal);
            }
            else if(goalType == 4) {
                int isComplete = readInt(goalStr, 1, ref goalInd);
                int penalty = readInt(goalStr, 8, ref goalInd);

                FailableGoal goal = new FailableGoal(shortName, description, points, penalty);

                if(isComplete == 1) {
                    goal.MarkComplete();
                }
                _goals.Add(goal);
            }
            else if(goalType == 5) {
                int amountCompleted = readInt(goalStr, 8, ref goalInd);
                int target = readInt(goalStr, 8, ref goalInd);
                int bonus = readInt(goalStr, 8, ref goalInd);

                ProgressGoal goal = new ProgressGoal(shortName, description, points, target, bonus);

                goal.MarkComplete(amountCompleted);
                
                _goals.Add(goal);
            }
            
        }

        int readInt(string fileString, int length, ref int ind) {
            int value = Convert.ToInt32(fileString[ind..(ind+length)], 16);
            //Console.WriteLine($"readInt read: \"{fileString[ind..(ind+length)]}\"");
            ind += length;
            return value;
        }
        string readString(string fileString, int length, ref int ind) {
            string value = fileString[ind..(ind+length)];
            //Console.WriteLine($"readString read: \"{fileString[ind..(ind+length)]}\"");
            ind += length;
            return value;
        }
    }
}