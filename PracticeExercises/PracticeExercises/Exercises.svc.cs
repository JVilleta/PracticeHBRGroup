using PracticeExercises.Controller;
using PracticeExercises.DataContract;
using System.Linq;

namespace PracticeExercises
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Excercises : IExercisesController
    {
        DataContractResponse MessegeResponse = new DataContractResponse();
        MathematicalOperations mathematicalOperations = new MathematicalOperations();
        public string GetExercise1(DataContractExcercises exercise)
        {
            double div = mathematicalOperations.Division(exercise.firtsNumber, exercise.secondNumber);
            double results = exercise.firtsNumber % exercise.secondNumber;

            MessegeResponse.Response = $"La división es: {div} El residuo es: {results}";

            return MessegeResponse.Response;
        }

        public string GetExercise2(DataContractExcercises exercise)
        {
            double results = exercise.firtsNumber % exercise.secondNumber;

            if (results == 0)
                return $"El primer número es ({exercise.firtsNumber}) y es multiplo del segundo número ({exercise.secondNumber})";
            else
                return $"El primer número es ({exercise.firtsNumber}) y no es multiplo del segundo número ({exercise.secondNumber})";
        }

        public string GetExercise3(DataContractExcercises exercise)
        {
            if (exercise.firtsNumber == 0)
            {
                MessegeResponse.Response = "El producto de 0 por cualquier número es 0";
            }
            else
            {
               var result = mathematicalOperations.Multiplication(exercise.firtsNumber, exercise.secondNumber);
               MessegeResponse.Response = $"El resultado de la multiplicacion es {result}";
            }
            return MessegeResponse.Response;
        }

        public string GetExercise4(DataContractExcercises exercise)
        {
            if (exercise.firtsNumber == 0 || exercise.secondNumber == 0)
            {
                MessegeResponse.Response = "Error: No se puede dividir entre cero";
            }
            else
            {
                var result = mathematicalOperations.Division(exercise.firtsNumber, exercise.secondNumber);
                MessegeResponse.Response = $"El resultado de la division es {result}";
            }
            return MessegeResponse.Response;
        }

        public string GetExercise5(DataContractExcercises exercise)
        {
            string[] vocals = { "A", "E", "I", "O", "U" };
            if (exercise.vocal.Trim() == vocals.FirstOrDefault())
            {
               MessegeResponse.Response = $"La letra es una vocal {exercise.vocal}";
            }
            else
            {
                MessegeResponse.Response = $"La letra ingresada no es una vocal {exercise.vocal}";
            }
            return MessegeResponse.Response;
        }

        public string GetExercise6(DataContractExcercises exercise)
        {
            if (exercise.firtsNumber >= 0 || exercise.secondNumber >= 0)
               MessegeResponse.Response = "Uno de los numero es positivo";        
            else if (exercise.firtsNumber >= 0 && exercise.secondNumber >= 0)        
                MessegeResponse.Response = "Los 2 numeros son posistivos";         
            else
                MessegeResponse.Response = "Ninguno de los numeros es positivo";
            
            return MessegeResponse.Response;
        }

        public string GetExercise7(DataContractExcercises exercise)
        {
            int number = exercise.firtsNumber;
            var result = number >= 0 ? number : number * -1;
            MessegeResponse.Response = $"El numero absoluto es:{result}";

            return MessegeResponse.Response;
        }

        public string[] GetExercise8()
        {
            int index = 1;         
            MessegeResponse.ResponseArray = new string[9];

            while (index <= 10)
            {
                MessegeResponse.ResponseArray[index - 1] = $"{index}";
                index++;
            }
            return MessegeResponse.ResponseArray;
        }

        public string[] GetExercise9()
        {
            int counter = 26, index =0;
            MessegeResponse.ResponseArray = new string[9];

            while (counter >= 10)
            {
                if (counter % 2 == 0)
                {
                    MessegeResponse.ResponseArray[index] = $"{counter}";
                    index +=1;
                }
                counter--;
            }
            return MessegeResponse.ResponseArray;
        }

        public string[] GetExercise10()
        {
            int number = 1;
            MessegeResponse.ResponseArray = new string[9];
            do
            {
                MessegeResponse.ResponseArray[number - 1] = $"{number}";
                number++;

            } while (number <= 10);
            return MessegeResponse.ResponseArray;
        }

        public string[] GetExercise11()
        {
            int counter = 26, index = 0;
            MessegeResponse.ResponseArray = new string[9];

            do
            {
                if (counter % 2 == 0)
                {
                    MessegeResponse.ResponseArray[index] = $"{counter}";
                    index +=1;
                }
                counter--;
            }
            while (counter >= 10);

            return MessegeResponse.ResponseArray;
        }

        public string[] GetExercise12()
        {
            int number = 15, index =0;
            MessegeResponse.ResponseArray = new string[9];

            while (number >= 5)
            {
                MessegeResponse.ResponseArray[index] = $"{number}";
                index += 1;
                number--;
            }
            return MessegeResponse.ResponseArray;
        }

        public string[] GetExercise13()
        {
            int index = 0;
            MessegeResponse.ResponseArray = new string[7];

            for (int counter = 2; counter <= 16; counter = counter + 2)
            {
                MessegeResponse.ResponseArray[index] = $"{counter}";
                index += 1;
            }

            return MessegeResponse.ResponseArray;
        }

        public string[] GetExercise14()
        {
            int number = 1;
            MessegeResponse.ResponseArray = new string[49];
            do
            {
                if (number % 3 == 0)
                    MessegeResponse.ResponseArray[number -1] = $"{number}";
                number++;

            } while (number <= 50);
            return MessegeResponse.ResponseArray;
        }

        public string GetExercise15(DataContractExcercises exercise)
        {
            MessegeResponse.Response = string.Empty;

            int minor = exercise.numbers[0];
            for (int counter = 0; counter < exercise.numbers.Length; counter++)
            {
                if (exercise.numbers[counter] < minor)
                    minor = exercise.numbers[counter];
            }

            int count = 0;
            for (int counter = 0; counter < exercise.numbers.Length; counter++)
            {
                if (exercise.numbers[counter] == minor)
                    count++;
            }

            MessegeResponse.Response += $"El menor es {minor}";

            if (count > 1)
                MessegeResponse.Response += ", El menor se repite";

            return MessegeResponse.Response;
        }

        public string GetExercise16(DataContractExcercises exercise)
        {
            MessegeResponse.Response = string.Empty;

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if ( exercise.salaries[counter] > exercise.salaries[counter + 1])
                    {
                        double major = exercise.salaries[counter];
                        exercise.salaries[counter] = exercise.salaries[counter + 1];
                        exercise.salaries[counter + 1] = major;
                    }
                }
            }
            foreach (var salaries in exercise.salaries)
               MessegeResponse.Response = salaries + ", ";

            return MessegeResponse.Response;
        }

        public string GetExercise17(DataContractExcercises exercise)
        {
            MessegeResponse.Response = string.Empty;
            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (exercise.countries[counter].CompareTo(exercise.countries[counter + 1]) > 0)
                    {
                        string major = exercise.countries[counter];
                        exercise.countries[counter] = exercise.countries[counter + 1];
                        exercise.countries[counter + 1] = major;
                    }
                }
            }

            foreach (var contries in exercise.countries)
                MessegeResponse.Response = contries + ", ";

            return MessegeResponse.Response;
        }

        public string GetExercise18(DataContractExcercises exercise)
        {
            MessegeResponse.Response = string.Empty;

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (exercise.populations[counter] < exercise.populations[counter + 1])
                    {
                        int major = exercise.populations[counter];
                        exercise.populations[counter] = exercise.populations[counter + 1];
                        exercise.populations[counter + 1] = major;
                    }
                }
            }

            for (int counter = 0; counter < 5; counter++)      
                MessegeResponse.Response += $" {exercise.countries[counter]}: {exercise.populations[counter]},";
            

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (exercise.countries[counter].CompareTo(exercise.countries[counter + 1]) > 0)
                    {
                        string major = exercise.countries[counter];
                        exercise.countries[counter] = exercise.countries[counter + 1];
                        exercise.countries[counter + 1] = major;
                    }
                }
            }

            MessegeResponse.Response += "";

            for (int counter = 0; counter < 5; counter++     
                MessegeResponse.Response += $" {exercise.countries[counter]}: {exercise.populations[counter]},";
            

            return MessegeResponse.Response;
        }

        public string GetExercise19(DataContractExcercises exercise)
        {
           MessegeResponse.Response = string.Empty;

            for (int rows = 0; rows < exercise.matrix.Length; rows++)
            {
                for (int columns = 0; columns < exercise.matrix[rows].Length; columns++)       
                    MessegeResponse.Response += $" {exercise.matrix[rows][columns]},";              
            }

            return MessegeResponse.Response;
        }


        public string GetExercise20(DataContractExcercises exercise)
        {
            exercise.temperatureQuarterly = new int[3];
            MessegeResponse.Response = string.Empty;

            for (int rows = 0; rows < exercise.countries.Length; rows++)
            {
                MessegeResponse.Response += $" Provincia: {exercise.countries[rows]}: ";

                for (int columns = 0; columns < exercise.temperature[rows].Length; columns++)             
                    MessegeResponse.Response += $" {exercise.temperature[rows][columns]},";
                
            }

            for (int rows = 0; rows < exercise.temperature.Length; rows++)
            {
                int sum = 0;
                for (int columns = 0; columns < exercise.temperature[rows].Length; columns++)        
                    sum = sum + exercise.temperature[rows][columns];
                
                exercise.temperatureQuarterly[rows] = sum / 3;
            }

            MessegeResponse.Response += " Temperaturas trimestrales.";
            for (int rows = 0; rows < exercise.countries.Length; rows++)        
                MessegeResponse.Response += $" {exercise.countries[rows]}: {exercise.temperatureQuarterly[rows]},";
            

            int HigherTemp = exercise.temperatureQuarterly[0];
            string HigherCountry = exercise.countries[0];
            for (int rows = 0; rows < exercise.countries.Length; rows++)
            {
                if (exercise.temperatureQuarterly[rows] > HigherTemp)
                {
                    HigherTemp = exercise.temperatureQuarterly[rows];
                    HigherCountry = exercise.countries[rows];
                }
            }
            MessegeResponse.Response += $" La provincia con temperatura trimestral mayor es" +
                $" {HigherCountry} que tiene una temperatura de {HigherTemp}";

            return MessegeResponse.Response;
        }

        public string GetExercise21(DataContractExcercises exercise)
        {
           MessegeResponse.Response = string.Empty;

            for (int rows = 0; rows < exercise.matrix.Length; rows++)
            {
                for (int columns = 0; columns < exercise.matrix[rows].Length; columns++)    
                    MessegeResponse.Response += $" {exercise.matrix[rows][columns]},";      
            }

            return MessegeResponse.Response;
        }

        public string GetExercise22(DataContractExcercises exercise)
        {
             MessegeResponse.Response = string.Empty;

            for (int rows = 0; rows < exercise.absences.Length; rows++)
            {
                MessegeResponse.Response += $" {exercise.nameEmployee[rows]},";

                for (int column = 0; column < exercise.absences[rows].Length; column++)            
                    MessegeResponse.Response += $" {exercise.absences[rows][column]}";   
            }

            return MessegeResponse.Response;
        }

        public string GetExercise23(DataContractExcercises exercise)
        {
            string element;
            MessegeResponse.Response = string.Empty;

            for (int numberRows = 0; numberRows < exercise.matrix.Length; numberRows++)
            {
                element = exercise.matrix[0][numberRows];
                exercise.matrix[0][numberRows] = exercise.matrix[1][numberRows];
                exercise.matrix[1][numberRows] = element;
            }

            for (int numberRows = 0; numberRows < exercise.matrix.Length; numberRows++)
            {
                for (int numberColumns = 0; numberColumns < exercise.matrix[numberRows].Length; numberColumns++)            
                    MessegeResponse.Response += $" {exercise.matrix[numberRows][numberColumns]},";
                
                MessegeResponse.Response += "";
            }

            return MessegeResponse.Response;
        }

        public string GetExercise24(DataContractExcercises exercise)
        {
            int lastRowIndex = exercise.matrix.Length - 1;
            int lastColumnIndex = exercise.matrix[0].Length - 1;

            return $"Vertices: {exercise.matrix[0][0]}, {exercise.matrix[0][lastColumnIndex]}, " +
                $"{exercise.matrix[lastRowIndex][0]}, {exercise.matrix[lastRowIndex][lastColumnIndex]}";
        }
    }
}
