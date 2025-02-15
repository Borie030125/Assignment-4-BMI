using System;
using Microsoft.Maui.Controls;

namespace BMI
{
    public partial class BMIResultPage : ContentPage
    {
        private string selectedGender;
        private double height;
        private double weight;
        private double bmi;
        private string bmiCategory;

        public BMIResultPage(string gender, double heightValue, double weightValue)
        {
            InitializeComponent();
            selectedGender = gender;
            height = heightValue;
            weight = weightValue;

            CalculateBMI();
            DisplayBMI();
        }

        private void CalculateBMI()
        {
            if (height <= 0) height = 1;
            bmi = (weight / (height * height)) * 703;

            if (selectedGender == "Male")
            {
                if (bmi < 18.5)
                    bmiCategory = "Underweight";
                else if (bmi < 25)
                    bmiCategory = "Normal weight";
                else if (bmi < 30)
                    bmiCategory = "Overweight";
                else
                    bmiCategory = "Obese";
            }
            else  // Female
            {
                if (bmi < 18)
                    bmiCategory = "Underweight";
                else if (bmi < 24)
                    bmiCategory = "Normal weight";
                else if (bmi < 29)
                    bmiCategory = "Overweight";
                else
                    bmiCategory = "Obese";
            }
        }

        private void DisplayBMI()
        {
            BMIValueLabel.Text = $"BMI: {bmi:F1}";
            BMICategoryLabel.Text = $"Category: {bmiCategory}";
        }

        private async void OnViewRecommendations(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HealthRecommendationsPage(selectedGender, bmiCategory));
        }

        private async void OnBackToInput(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
