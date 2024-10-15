using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ClaimsManagementSystem
{
    public partial class ClaimVerification : Window
    {
        public List<Claim> ClaimsList { get; set; } = new List<Claim>(); // Sample list of claims

        public ClaimVerification()
        {
            InitializeComponent();
            LoadClaims(); // Load claims to display
        }

        private void LoadClaims()
        {
            // Load claims from database or a collection
            // For demonstration, adding a sample claim
            ClaimsList.Add(new Claim { LecturerName = "John Doe", HoursWorked = 10, HourlyRate = 25.00M, Status = "Pending", AdditionalNotes = "Taught Introduction to Programming." });
            ClaimsList.Add(new Claim { LecturerName = "Jane Smith", HoursWorked = 5, HourlyRate = 30.00M, Status = "Pending", AdditionalNotes = "Conducted a special seminar on Advanced Data Structures." });
            ClaimsList.Add(new Claim { LecturerName = "Robert Johnson", HoursWorked = 8, HourlyRate = 20.00M, Status = "Pending", AdditionalNotes = "Office hours for student consultations." });
            ClaimsList.Add(new Claim { LecturerName = "Emily Davis", HoursWorked = 12, HourlyRate = 28.50M, Status = "Pending", AdditionalNotes = "Assisted with curriculum development for the new course." });
            ClaimsList.Add(new Claim { LecturerName = "Michael Brown", HoursWorked = 5, HourlyRate = 35.00M, Status = "Pending", AdditionalNotes = "Guest lecture on Machine Learning." });
            ClaimsList.Add(new Claim { LecturerName = "Linda Green", HoursWorked = 10, HourlyRate = 27.00M, Status = "Pending", AdditionalNotes = "Workshop on effective teaching strategies." });
            ClaimsList.Add(new Claim { LecturerName = "Chris White", HoursWorked = 6, HourlyRate = 22.50M, Status = "Pending", AdditionalNotes = "Mentored students for the final project." });
            ClaimsList.Add(new Claim { LecturerName = "Sarah Johnson", HoursWorked = 7, HourlyRate = 30.00M, Status = "Pending", AdditionalNotes = "Provided guest lectures on Data Science." });
            ClaimsList.Add(new Claim { LecturerName = "David Miller", HoursWorked = 9, HourlyRate = 32.00M, Status = "Pending", AdditionalNotes = "Conducted an online course on Software Engineering." });
            ClaimsList.Add(new Claim { LecturerName = "Lisa Brown", HoursWorked = 4, HourlyRate = 26.00M, Status = "Pending", AdditionalNotes = "Held an exam review session." });
            ClaimsList.Add(new Claim { LecturerName = "Kevin Wilson", HoursWorked = 11, HourlyRate = 29.50M, Status = "Pending", AdditionalNotes = "Worked on the accreditation process." });
            ClaimsListView.ItemsSource = ClaimsList; // Bind the claims to the ListView
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((Button)sender).DataContext;
            claim.Status = "Approved";
            UpdateClaimStatus(claim);
            MessageBox.Show("Claim approved.");
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((Button)sender).DataContext;
            claim.Status = "Rejected";
            UpdateClaimStatus(claim);
            MessageBox.Show("Claim rejected.");
        }

        private void UpdateClaimStatus(Claim claim)
        {
            // Update claim in the database or data structure
            // Refresh UI if necessary
            ClaimsListView.Items.Refresh(); // Refresh the ListView to show updated statuses
        }

        private void ClaimsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
