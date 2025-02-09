using System;
using Microsoft.Maui.Controls;

namespace BMI;

public partial class BMIPage : ContentPage
{
    private string selectedGender = "Male"; 

    public BMIPage()
    {
        InitializeComponent();
        UpdateGenderSelection();
    }

    private void OnMaleTapped(object sender, EventArgs e)
    {
        selectedGender = "Male";
        UpdateGenderSelection();
    }

    private void OnFemaleTapped(object sender, EventArgs e)
    {
        selectedGender = "Female";
        UpdateGenderSelection();
    }

    private void UpdateGenderSelection()
    {
        if (selectedGender == "Male")
        {
            MaleFrame.BorderColor = Colors.Blue;   
            FemaleFrame.BorderColor = Colors.Transparent;
        }
        else
        {
            MaleFrame.BorderColor = Colors.Transparent;
            FemaleFrame.BorderColor = Colors.Pink;   
        }
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        HeightLabel.Text = $"{HeightSlider.Value:0} in";
        WeightLabel.Text = $"{WeightSlider.Value:0} lbs";
    }

    private void CalculateBMI(object sender, EventArgs e)
    {
        double height = HeightSlider.Value;
        double weight = WeightSlider.Value;
        double bmiFactor = selectedGender == "Male" ? 703 : 700;
        double bmi = (weight / (height * height)) * bmiFactor;

        string status = GetBMIStatus(bmi, selectedGender);
        string recommendations = GetRecommendations(status);

        DisplayAlert("BMI Results",
            $"Gender: {selectedGender}\nBMI: {bmi:F1}\nStatus: {status}\n\n{recommendations}",
            "OK");
    }

    private string GetBMIStatus(double bmi, string gender)
    {
        if (gender == "Male")
        {
            if (bmi < 18.5) return "Underweight";
            else if (bmi < 25) return "Normal weight";
            else if (bmi < 30) return "Overweight";
            else return "Obese";
        }
        else  // Female
        {
            if (bmi < 18) return "Underweight";
            else if (bmi < 24) return "Normal weight";
            else if (bmi < 29) return "Overweight";
            else return "Obese";
        }
    }

    private string GetRecommendations(string status)
    {
        return status switch
        {
            "Underweight" => "Increase calorie intake with nutrient-rich foods and muscle-building exercises.",
            "Normal weight" => "Maintain a balanced diet and stay active with regular workouts.",
            "Overweight" => "Focus on portion control, healthy eating, and consistent exercise.",
            "Obese" => "Consult a healthcare provider for guidance on weight management strategies.",
            _ => ""
        };
    }
}
