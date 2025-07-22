using Microsoft.ML.Data;

namespace FinTech.Models
{
    public class TransactionData
    {
        public float Amount { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public float AccountBalance { get; set; }
        public string TransactionTime { get; set; } = string.Empty;
        public string MerchantCategory { get; set; } = string.Empty;
        public string DeviceType { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public float AccountAgeDays { get; set; }
        public float NumTransactions24h { get; set; }
        public float AvgTransactionAmount7d { get; set; }
        public float PreviousFraudCount { get; set; }
    }

    public class TransactionPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool PredictedLabel { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }
} 