using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Util
{
    public class LinearRegression
    {
        private double[] normalizedYears;
        private double[] examResults;
        private int firstYear;

        public LinearRegression(int[] years, double[] examResults)
        {
            firstYear = years.Min();
            this.normalizedYears = years.Select(year => (double)(year - firstYear)).ToArray();
            this.examResults = examResults;
        } 
        public LinearRegression()
        {
  
        }

        private double CalculateMean(double[] values)
        {
            return values.Average();
        }

        private (double slope, double yIntercept) CalculateLinearRegression()
        {
            int N = normalizedYears.Length;
            double sumX = normalizedYears.Sum();
            double sumY = examResults.Sum();
            double sumXY = 0;
            double sumXSquare = 0;

            for (int i = 0; i < N; i++)
            {
                sumXY += normalizedYears[i] * examResults[i];
                sumXSquare += normalizedYears[i] * normalizedYears[i];
            }

            double slope = (N * sumXY - sumX * sumY) / (N * sumXSquare - sumX * sumX);
            double yIntercept = (sumY - slope * sumX) / N;

            return (slope, yIntercept);
        }

        public double Predict(int year)
        {
            var (slope, yIntercept) = CalculateLinearRegression();
            return slope * (year - firstYear) + yIntercept;
        }
        public double EstimateAdmissionProbability(double userScore, double predictedScore)
        {
            double difference = userScore - predictedScore;

            // Apply a sigmoid function to interpret the difference as a probability
            double probability = 1 / (1 + Math.Exp(-difference));
            return probability;
        }
        public double PredictNextValue(double[] observations)
        {
            int N = observations.Length;
            double sum_x = 0;
            double sum_y = 0;
            double sum_xy = 0;
            double sum_x_squared = 0;

            for (int i = 0; i < N; i++)
            {
                sum_x += i + 1;
                sum_y += observations[i];
                sum_xy += (i + 1) * observations[i];
                sum_x_squared += Math.Pow(i + 1, 2);
            }

            double m = (N * sum_xy - sum_x * sum_y) / (N * sum_x_squared - Math.Pow(sum_x, 2));
            double b = (sum_y - m * sum_x) / N;

            // Predict the next value for time step N + 1
            double next_time_step = N + 1;
            double predicted_value = m * next_time_step + b;

            return predicted_value;
        }
    }
}
