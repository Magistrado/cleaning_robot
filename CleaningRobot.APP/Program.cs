using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot.APP
{
    interface IOHandler
    {
        string read(string path);
        void write(string path);
    }

    class TextFileHandler : IOHandler
    {
        string content = string.Empty;

        public TextFileHandler() { }


        public TextFileHandler(string content)
        {
            this.content = content;
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                this.content = value;
            }
        }

        public string read(string path)
        {
            string text = null;
            try
            {
                text = File.ReadAllText(path);
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return text;
        }

        public void write(string path)
        {
            try
            {
                File.WriteAllText(path, content);
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Program
    {
        public static ProcessingControl createRobot(InputData id)
        {
            OpMap map = new OpMap(id.map, id.start.facing, id.start.X, id.start.Y);
            IMotionControl motCtrl = new MotionControl(id.battery);
            return new ProcessingControl(motCtrl, map);
        }

        static void Main(string[] args)
        {
            string source = string.Empty;
            string result = string.Empty;
            TextFileHandler txtHandler = new TextFileHandler();

            if ( args.Length > 2 || args.Length < 2 )
            {
                Console.WriteLine("Execution: program source.json result.json. \nPlease, specify two valid JSON files.");
                return;
            }

            source = txtHandler.read(args[0]);
            if ( source == null )
            {
                Console.WriteLine("{0} cannot be read. Please, specify a valid source JSON file.", args[0]);
            }

            InputData id = InputData.parseToInputData(source);
            ProcessingControl pc = createRobot(id);

            // Execute robot
            pc.execProgram(id.commands);


            // Write output to disk
            Stats stats = pc.getStats();
            txtHandler.Content = stats.outputToPrettyJSON();
            txtHandler.write(args[1]);    
        }
    }
}

