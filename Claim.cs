public class Claim
{
    public string LecturerName { get; set; }  // Name of the lecturer
    public int HoursWorked { get; set; }       // Hours worked
    public decimal HourlyRate { get; set; }    // Hourly rate
    public string AdditionalNotes { get; set; } // Additional notes
    public string Status { get; set; }          // Claim status (e.g., Pending, Approved, Rejected)
    public string SupportingDocument { get; set; } // Path to supporting document
}
