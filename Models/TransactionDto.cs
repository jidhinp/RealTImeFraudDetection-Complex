namespace FinTech.Models
{
    public class TransactionDto
    {
        public string TransactionId { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public double AccountBalance { get; set; }
        public string TransactionTime { get; set; } = string.Empty;
        public string MerchantCategory { get; set; } = string.Empty;
        public string DeviceType { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double AccountAgeDays { get; set; }
        public double NumTransactions24h { get; set; }
        public double AvgTransactionAmount7d { get; set; }
        public double PreviousFraudCount { get; set; }
    }
} 