namespace Alexa.NET.Management.Internals
{
    public class NluApiContainer
    {
        public NluApiContainer(INluAnnotationSetApi annotationSets, INluEvaluationApi evaluations)
        {
            AnnotationSets = annotationSets;
            Evaluations = evaluations;
        }
        public INluAnnotationSetApi AnnotationSets { get; }

        public INluEvaluationApi Evaluations { get; }
    }
}