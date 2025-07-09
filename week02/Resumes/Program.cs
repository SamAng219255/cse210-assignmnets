using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        job1._startYear = 2026;
        job1._endYear = 2036;
        Job job2 = new Job();
        job2._jobTitle = "Programmer";
        job2._company = "Perfectly Generic Team";
        job2._startYear = 2019;
        job2._endYear = 2020;

        Resume resume = new Resume();
        resume._name = "Sam Anguiano";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}