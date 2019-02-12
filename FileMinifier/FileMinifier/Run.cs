using FileServices;

namespace FileMinifier
{
    public class Run
    {
        private readonly ConsoleIO _console;
        private readonly ValidateFile _validate;  
        public Run(ConsoleIO console, ValidateFile validate)
        {
            _console = console;
            _validate = validate;   
        }

        public void StartMinimise()
        {
            var inputFilePath = _console.IntakeFilePath();

            bool acceptFile = _validate.CheckValidLocation(inputFilePath);
            if (!acceptFile)
            {
                do
                {
                    _console.FileLocationNotFound();

                    inputFilePath = _console.IntakeFilePath();

                } while (_validate.CheckValidLocation(inputFilePath) == false);
            }
            MinifyFileService.SplitFile(inputFilePath, 1000, "C:\\Users\\RyanB\\OneDrive\\Documents\\TestingMinimiser\\BrokenDownFiles");

            GlueFilesService.CombineMultipleFilesIntoSingleFile("C:\\Users\\RyanB\\OneDrive\\Documents\\TestingMinimiser\\BrokenDownFiles", "f*", "C:\\Users\\RyanB\\OneDrive\\Documents\\TestingMinimiser\\GluedFile");
        }
    }
}
