using System;

namespace UtilityBillsCalculator
{
    public class UtilityBillCalculator
    {
        public static string CalculateUtilityBills(int roomArea, int numberOfPeople, string season, bool hasLaborVeteranBenefit, bool hasWarVeteranBenefit)
        {
            double heatingTariff = CalculateHeatingTariff(roomArea, season);
            double waterTariff = CalculateWaterTariff(numberOfPeople);
            double gasTariff = CalculateGasTariff(numberOfPeople);
            double maintenanceTariff = CalculateMaintenanceTariff(roomArea);

            if (hasLaborVeteranBenefit)
            {
                heatingTariff *= 0.7;
                maintenanceTariff *= 0.7; 
            }

            if (hasWarVeteranBenefit)
            {
                heatingTariff *= 0.5;
                maintenanceTariff *= 0.5;
            }

            string table = "Type of payment\tAccrued\tPreferential\n";
            table += $"Heating\t{heatingTariff}\t{(hasLaborVeteranBenefit || hasWarVeteranBenefit ? "Yes" : "No")}\n";
            table += $"Water\t{waterTariff}\t{(hasWarVeteranBenefit ? "Yes" : "No")}\n";
            table += $"Gas\t{gasTariff}\t{(hasWarVeteranBenefit ? "Yes" : "No")}\n";
            table += $"Maintenance\t{maintenanceTariff}\t{(hasLaborVeteranBenefit || hasWarVeteranBenefit ? "Yes" : "No")}\n";

            return table;
        }

        private static double CalculateHeatingTariff(int roomArea, string season)
        {
            double baseTariff = 10;

            if (season == "autumn" || season == "winter")
            {
                baseTariff *= 1.5;
            }

            return baseTariff * roomArea;
        }
        private static double CalculateWaterTariff(int numberOfPeople)
        {
            double baseTariff = 20;

            return baseTariff * numberOfPeople;
        }
        private static double CalculateGasTariff(int numberOfPeople)
        {
            double baseTariff = 15;

            return baseTariff * numberOfPeople;
        }

        private static double CalculateMaintenanceTariff(int roomArea)
        {
            double baseTariff = 5;

            return baseTariff * roomArea;
        }
    }

    public class Program
    {
        public static void Main()
        {
            int roomArea = 100;
            int numberOfPeople = 3;
            string season = "winter";
            bool hasLaborVeteranBenefit = true;
            bool hasWarVeteranBenefit = false;

            string utilityBillsTable = UtilityBillCalculator.CalculateUtilityBills(roomArea, numberOfPeople, season, hasLaborVeteranBenefit, hasWarVeteranBenefit);
            Console.WriteLine(utilityBillsTable);
        }
    }
}