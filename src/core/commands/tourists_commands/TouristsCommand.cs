using Lalalend_3.core;
using Lalalend_3.core.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lalalend_3.src.core.commands.tourists_commands
{
    internal class TouristsCommand : IChartCommand
    {
        List<List<string>> data;
        public TouristsCommand(List<List<string>> data) 
        { 
            this.data = data;
        }
        public void Run(IChartPresenter presenter)
        {
            presenter.ShowGrid(new List<string>() { "Год", "Тур поток Европа (млн. чел.)", "Тур поток Азия (млн. чел.)", "Тур поток Америка (млн. чел.)", "Тур поток Австралия (млн. чел.)", }, data);

            Series europe = new Series();
            Series asia = new Series();
            Series USA = new Series();
            Series australia = new Series();

            europe.Name = "Европа";
            asia.Name = "Азия";
            USA.Name = "Америка";
            australia.Name = "Австралия";

            europe.ChartType = SeriesChartType.FastLine;
            asia.ChartType = SeriesChartType.FastLine;
            USA.ChartType = SeriesChartType.FastLine;
            australia.ChartType = SeriesChartType.FastLine;

            float europeSum = 0, asiaSum = 0, USASum = 0, australiaSum = 0;
            
            foreach (var data_ in data)
            {
                europe.Points.AddXY(data_[0], data_[1]);
                asia.Points.AddXY(data_[0], data_[2]);
                USA.Points.AddXY(data_[0], data_[3]);
                australia.Points.AddXY(data_[0], data_[4]);

                europeSum += float.Parse(data_[1]);
                asiaSum += float.Parse(data_[2]);
                USASum += float.Parse(data_[3]);
                australiaSum += float.Parse(data_[4]);
            }

            float[] worldSum = { europeSum, asiaSum, USASum, australiaSum };
            string answer = "";
            if (worldSum.Max() == europeSum)
            {
                answer = "Европа (" + europeSum + " млн. чел.)";
            }
            else if (worldSum.Max() == asiaSum)
            {
                answer = "Азия (" + asiaSum + " млн. чел.)";
            }
            else if (worldSum.Max() == USASum)
            {
                answer = "Америка (" + USASum + " млн. чел.)";
            }
            else if (worldSum.Max() == australiaSum)
            {
                answer = "Австралия (" + australiaSum + " млн. чел.)";
            }

            presenter.ShowChart(new List<Series> { europe, asia, USA, australia });

            presenter.ShowAdditionalInfo("Наибольший турпоток: " + answer);
        }
    }
}
