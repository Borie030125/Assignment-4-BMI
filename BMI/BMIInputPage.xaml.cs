using System;
using Microsoft.Maui.Controls;

namespace BMI
{
    public partial class BMIInputPage : ContentPage
    {
        private string selectedGender = "Male";  
        public double HeightValue { get; set; } = 50;
        public double WeightValue { get; set; } = 90;

        public BMIInputPage()
        {
            InitializeComponent();
            HeightLabel.Text = $"{HeightSlider.Value}";
            WeightLabel.Text = $"{WeightSlider.Value}";
        }

        private void OnMaleTapped(object sender, EventArgs e)
        {
            selectedGender = "Male";
            MaleFrame.BorderColor = Colors.Blue;
            FemaleFrame.BorderColor = Colors.Transparent;
        }

        private void OnFemaleTapped(object sender, EventArgs e)
        {
            selectedGender = "Female";
            FemaleFrame.BorderColor = Colors.Pink;
            MaleFrame.BorderColor = Colors.Transparent;
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            HeightValue = HeightSlider.Value;
            WeightValue = WeightSlider.Value;
            HeightLabel.Text = $"{(int)HeightValue}";
            WeightLabel.Text = $"{(int)WeightValue}";
        }

        private async void OnCalculateBMI(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BMIResultPage(selectedGender, HeightValue, WeightValue));
        }
    }
}
