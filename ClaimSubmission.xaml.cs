using Microsoft.Win32;
using System;
using System.Windows;

namespace ClaimsManagementSystem
{
    public partial class ClaimSubmission : Window
    {
        public ClaimSubmission()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Documents|*.pdf;*.docx;*.xlsx",
                Title = "Select Supporting Document"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Store file path securely or upload to a server
                UploadedFileName.Text = $"Uploaded: {openFileDialog.FileName}";
            }
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrEmpty(LecturerNameTextBox.Text) ||
                string.IsNullOrEmpty(HoursWorkedTextBox.Text) ||
                string.IsNullOrEmpty(HourlyRateTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Try parsing the numeric fields (HoursWorked and HourlyRate) to avoid format exceptions
            if (!int.TryParse(HoursWorkedTextBox.Text, out int hoursWorked))
            {
                MessageBox.Show("Please enter a valid number for Hours Worked.");
                return;
            }

            if (!decimal.TryParse(HourlyRateTextBox.Text, out decimal hourlyRate))
            {
                MessageBox.Show("Please enter a valid number for Hourly Rate.");
                return;
            }

            // Additional validation if needed
            if (hourlyRate <= 0 || hoursWorked <= 0)
            {
                MessageBox.Show("Hours Worked and Hourly Rate must be positive values.");
                return;
            }

            try
            {
                // Create and store the new claim
                var claim = new Claim
                {
                    LecturerName = LecturerNameTextBox.Text,
                    HoursWorked = hoursWorked,
                    HourlyRate = hourlyRate,
                    AdditionalNotes = NotesTextBox.Text,
                    SupportingDocument = UploadedFileName.Text, // Ensure this is not null
                    Status = "Pending"
                };

                // Save the claim to the database or a collection
                SaveClaim(claim);

                // Display success message
                MessageBox.Show("Claim submitted successfully!");
                this.Close(); // Close the form after successful submission
            }
            catch (FormatException ex)
            {
                // Handle any formatting errors
                MessageBox.Show("There was a problem with the input format. Please check your data.", "Error");
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
            }
        }

        private void SaveClaim(Claim claim)
        {
            // Implement logic to save the claim to the database or collection
            // For example, you can add it to the ClaimsList in the MainWindow class:
            // MainWindow.ClaimsList.Add(claim);

            // This is just a placeholder; adapt it based on your data storage method.
        }
    }
}
