using Lalalend_3.core.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lalalend_3.src.core.commands.tourists_commands
{
    internal class TouristsCommandFactory : AbstractCommandFactory
    {
        public override IChartCommand CreateFromCSV(string csv)
        {
            List<List<string>> splitedCsv = csv.Split('\n').ToList().Select((e) => e.Split(';').ToList()).ToList();
            return new TouristsCommand(splitedCsv);
        }
    }
}
