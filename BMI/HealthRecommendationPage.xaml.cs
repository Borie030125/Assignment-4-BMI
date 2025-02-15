using System;
using Microsoft.Maui.Controls;

namespace BMI
{
    public partial class HealthRecommendationsPage : ContentPage
    {
        private string selectedGender;
        private string bmiCategory;

        public HealthRecommendationsPage(string gender, string category)
        {
            InitializeComponent();
            selectedGender = gender;
            bmiCategory = category;
            DisplayRecommendations();
        }

        private void DisplayRecommendations()
        {
            string recommendations = "";

            if (bmiCategory == "Underweight")
            {
                recommendations = "Increase calorie intake with nutrient-rich foods and engage in muscle-building exercises.";
            }
            else if (bmiCategory == "Normal weight")
            {
                recommendations = "Maintain a balanced diet and continue with regular physical activity.";
            }
            else if (bmiCategory == "Overweight")
            {
                recommendations = "Consider portion control and incorporate more physical exercise into your routine.";
            }
            else if (bmiCategory == "Obese")
            {
                recommendations = "It is recommended to consult with a healthcare professional for tailored advice.";
            }

            RecommendationsLabel.Text = recommendations;
        }

        private async void OnBackToResult(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnBackToInput(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
