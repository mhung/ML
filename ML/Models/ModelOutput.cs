using Microsoft.ML.Data;


namespace ML.Models
{
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public string Prediction { get; set; }
    }
}
