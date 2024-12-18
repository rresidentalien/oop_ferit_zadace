using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class FilePrinter : IPrinter
    {
        private string outputFileName;

        public FilePrinter(string outputFileName)
        {
            this.outputFileName = outputFileName;
        }

        public void Print(string message)
        {
            using (StreamWriter outputFile = new StreamWriter(outputFileName))
            {
                outputFile.WriteLine(message);
            }
        }
    }
}
