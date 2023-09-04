
using System.Runtime.Serialization;

namespace PracticeExercises.Controller
{
    [DataContract]
    public class DataContractExcercises
    {
        [DataMember]
        public int firtsNumber { get; set; }
        [DataMember]
        public int secondNumber { get; set; }
        [DataMember]
        public string vocal { get; set; }
        [DataMember]
        public int[] numbers { get; set; }
        [DataMember]
        public double[] salaries { get; set; }
        [DataMember]
        public string[] countries { get; set; }
        [DataMember]
        public int[] populations { get; set; }
        [DataMember]
        public string[][] matrix { get; set; }
        [DataMember]
        public string[] nameEmployee { get; set; }
        [DataMember]
        public int[][] absences { get; set; }
        [DataMember]
        public int[][] temperature { get; set; }
        [DataMember]
        public int[] temperatureQuarterly { get; set; }
    }
}