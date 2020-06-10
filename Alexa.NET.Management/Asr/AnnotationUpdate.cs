using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.AnnotationSet
{
    public class AnnotationUpdate
    {
        [JsonProperty("uploadId")]
        public string UploadId { get; set; }

        [JsonProperty("filePathInUpload")]
        public string FilePathInUpload { get; set; }

        [JsonProperty("evaluationWeight")]
        public int EvaluationWeight { get; set; }

        [JsonProperty("expectedTranscription")]
        public string ExpectedTranscription { get; set; }
    }
}