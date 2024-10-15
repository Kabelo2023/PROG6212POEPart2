# PROG6212POEPart2


# Claims Management System

## Overview

The Claims Management System is a WPF (Windows Presentation Foundation) application built to allow lecturers to submit claims for hours worked. The system includes features for submitting claims, uploading supporting documents, and verifying claims.

### Project Structure

1. **MainWindow.xaml & MainWindow.xaml.cs**: This serves as the application's main window. It contains buttons for submitting claims and verifying them. Each button opens a separate window for these actions.
   
2. **ClaimSubmission.xaml & ClaimSubmission.xaml.cs**: This window allows the lecturer to submit a claim by filling out details such as the lecturer's name, hours worked, hourly rate, and any additional notes. A document can also be uploaded to support the claim. The claim is then saved for further processing.

3. **Unit Testing (UnitTest1.cs)**: Placeholder unit tests that can be expanded for testing functionalities of the claims system.

---

## How It Works

### 1. **MainWindow.xaml.cs**

The main window provides two buttons:
- **Submit Claim**: Opens the `ClaimSubmission` window where a new claim can be submitted.
- **Verify Claims**: Opens a `ClaimVerification` window (currently not implemented in the provided code).


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SubmitClaimButton_Click(object sender, RoutedEventArgs e)
    {
        var claimSubmissionWindow = new ClaimSubmission();
        claimSubmissionWindow.ShowDialog();
    }

    private void VerifyClaimsButton_Click(object sender, RoutedEventArgs e)
    {
        var claimVerificationWindow = new ClaimVerification();
        claimVerificationWindow.ShowDialog();
    }
}


2. ClaimSubmission.xaml.cs
This window handles the claim submission process. It collects information such as:

Lecturer's name.
Hours worked.
Hourly rate.
Additional notes.
Uploading a supporting document (like a PDF or Word file).
Key Features:
File Upload: When the "Upload" button is clicked, it opens a file dialog allowing the user to select a file with extensions .pdf, .docx, or .xlsx. Once a file is selected, its path is shown in the UI.

Form Validation: Before submitting, the system ensures all fields are filled in correctly. Numeric fields (Hours Worked and Hourly Rate) are validated to ensure the data type is correct and the values are positive.

Error Handling: Exceptions are caught, and user-friendly error messages are displayed if anything goes wrong.


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

        // Try parsing the numeric fields (HoursWorked and HourlyRate)
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

        // Ensure positive values for hours worked and hourly rate
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
                SupportingDocument = UploadedFileName.Text,
                Status = "Pending"
            };

            // Save the claim (placeholder for actual save logic)
            SaveClaim(claim);

            // Display success message
            MessageBox.Show("Claim submitted successfully!");
            this.Close(); // Close form after submission
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
        }
    }

    private void SaveClaim(Claim claim)
    {
        // Placeholder for saving the claim to a database or collection.
    }
}


3. ClaimSubmission.xaml
This file defines the UI layout for the ClaimSubmission window. It uses a StackPanel to organize the input fields, labels, and buttons vertically.

Key Elements:

Lecturer Name: A TextBox for entering the lecturer's name.
Hours Worked: A TextBox for entering the number of hours worked.
Hourly Rate: A TextBox for entering the hourly rate.
Additional Notes: A multi-line TextBox for entering optional notes.
File Upload: A button for uploading a supporting document, with a TextBlock displaying the file name once selected.
Submit Button: Submits the claim after validation.

<Window x:Class="ClaimsManagementSystem.ClaimSubmission"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Submit Claim" Height="300" Width="400">
    <Grid>
        <StackPanel Margin="20">
            <Label Content="Lecturer Name:" />
            <TextBox x:Name="LecturerNameTextBox" />

            <Label Content="Hours Worked:" />
            <TextBox x:Name="HoursWorkedTextBox" />

            <Label Content="Hourly Rate:" />
            <TextBox x:Name="HourlyRateTextBox" />

            <Label Content="Additional Notes:" />
            <TextBox x:Name="NotesTextBox" AcceptsReturn="True" Height="60" />

            <Label Content="Upload Supporting Document:" />
            <Button Content="Upload" Click="UploadButton_Click" />
            <TextBlock x:Name="UploadedFileName" />

            <Button Content="Submit Claim" Click="SubmitClaim_Click" Margin="0,20,0,0" />
        </StackPanel>
    </Grid>
</Window>


4. Unit Testing
The project includes a placeholder for unit testing. You can add methods to test various components, such as form validation, claim submission logic, and file uploading functionality.


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        // Implement test cases for the Claims Management System
    }
}
Future Enhancements
Claim Verification: Implement the ClaimVerification window to allow administrators to verify or reject submitted claims.
Data Persistence: Implement a proper data storage method (e.g., saving claims to a database or file system).
Unit Tests: Expand the unit testing coverage to ensure the reliability of the core functionality.
User Authentication: Add login and user roles for managing access to the system (e.g., lecturers, administrators).
How to Run
Open the project in Visual Studio.
Run the project to launch the main window.
Click on "Submit Claim" to open the claim submission form.
Fill in the required fields, upload a document, and submit the claim.
If the inputs are valid, a success message will be shown, and the form will close.
Conclusion
This project offers a simple claims management interface with features for submitting claims, uploading supporting documents, and verifying them. Future improvements include adding more robust validation, persistence, and verification functionality.
