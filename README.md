# Cleaning Robot

A exercise to show C# experience. It's finished but it fails on throwing good results due to a bug in the strategies results. Now, I had to spend time in other business.

This work using the command line in the following way: 

`$ cleaning_robot source.json result.json`

Good results are: 

```
results.json
{
  "map": [
    ["S", "S", "S", "S"],
    ["S", "S", "C", "S"],
    ["S", "S", "S", "S"],
    ["S", "null", "S", "S"]
  ],
  "start": {"X": 3, "Y": 1, "facing": "S"},
  "commands": [ "TR","A","C","A","C","TR","A","C"],
  "battery": 1094
}
```

```
source.json:
{
  "visited": [
    {
      "X": 2,
      "Y": 2
    },
    {
      "X": 3,
      "Y": 0
    },
    {
      "X": 3,
      "Y": 1
    },
    {
      "X": 3,
      "Y": 2
    }
  ],
  "cleaned": [
    {
      "X": 2,
      "Y": 2
    },
    {
      "X": 3,
      "Y": 0
    },
    {
      "X": 3,
      "Y": 2
    }
  ],
  "final": {
    "X": 3,
    "Y": 2,
    "facing": "E"
  },
  "battery": 1040
}
```


## My approach
The solution is splitted up two parts: a class library (it´s called cleaning_robot) where is the main code of cleaning robot and a console app (it´s called CleaningRobot.APP) which handle I/O and command line execution. The third class library is called "Tests", has all unittests. I have tested widely the cleaning robot library but I couldn't test the console application.

In the "cleaning_robot" project, there are a folder where are backoff strategies from one to five so it´s written in coding test statement. These five strategies implements an interface called "IBackoffStrategy" which uncouple the main code and allows to implement several strategies at will.

The strategies are stored inside ProcessingControl class (I shall discuss this class later). They are activated by the following exceptions: CannotComplyException, NotEnoughBatteryException, OutOfBatteryException  and, of course, an Exception. When any strategy is activated, it takes control over robot until it sucess or it fail. If one fail, it´s executed the next one.

ProcessingControl, MotionControl and Map classes are the main components. In Map class, it's the logic about facing and position within map. ProcessingControl  is in charged of coordination actions between Map and MotionControl. It receives a command list and put in action the robot. I used a design pattern: dependency injection because it enables testability by isolating this class from real implementations.

The CannotComplyException, NotEnoughBatteryException, OutOfBatteryException exceptions are custom ones. These reports to ProcessingControl such error events. If any of these exceptions is thrown, ProcessingControl handles it by executing backoff strategies.

IMotionControl is an interface which implementation is MotionControl. In this class is written the motion controls and their effect on the battery. Besides, it throws NotEnoughBatteryException and OutOfBatteryException.

Stats and Input Data are classes dedicated to deliver results and receive input. Newtonsoft.Json uses these classes for parsing JSON and load data or transform an Object to JSON.

I set up the unit cases in "Tests" library class. There are unittests for MotionControl, Map and Processing Control. Again, I couldn't test the console app. Within ProcessingControlTests, there are the test cases which you delivered.
