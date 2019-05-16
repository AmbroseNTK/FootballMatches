using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLib.DataProviders
{
    public class TextProvider : IProvider
    {
        private string fileName;

        public TextProvider(string fileName)
        {
            this.fileName = fileName;
        }
        public List<Team> Provide()
        {
            string data = System.IO.File.ReadAllText(fileName);
            string[] lines = data.Split('\n');

            return new List<Team>();
        }
    }
}
