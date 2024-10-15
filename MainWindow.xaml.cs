using System.Windows;

namespace ClaimsManagementSystem
{
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
}


