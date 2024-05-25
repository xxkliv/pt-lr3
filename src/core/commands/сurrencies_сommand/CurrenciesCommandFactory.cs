using Lalalend_3.core.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lalalend_3.src.core.commands.сurrencies_сommand
{
    internal class CurrenciesCommandFactory : AbstractCommandFactory
    {
        public override IChartCommand CreateFromCSV(string csv)
        {
            var csvList = csv.Split('\n').ToList();
            List<List<string>> list = csvList.Select((e) => e.Split(';').ToList()).ToList();

            return new CurrenciesCommand(list);
        }
    }
}
