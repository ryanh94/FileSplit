using FileServices;

namespace FileMinifier
{
    public class Run
    {
        private readonly ConsoleIO _console;
        private readonly ValidateFile _validate;
        private readonly GlueFilesService _glueFiles;
        private readonly MinifyFileService _minifyFile;

        public Run(ConsoleIO console, ValidateFile validate, GlueFilesService glueFiles, MinifyFileService minifyFile)
        {
            _console = console;
            _validate = validate;
            _glueFiles = glueFiles;
            _minifyFile = minifyFile;
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
            _minifyFile.SplitFile(inputFilePath, 1000, "C:\\Users\\RyanB\\OneDrive\\Documents\\TestingMinimiser\\BrokenDownFiles");

            var fileType = _validate.GetFileType(inputFilePath);

            _glueFiles.CombineMultipleFilesIntoSingleFile("C:\\Users\\RyanB\\OneDrive\\Documents\\TestingMinimiser\\BrokenDownFiles", "f*", $"C:\\Users\\RyanB\\OneDrive\\Documents\\TestingMinimiser\\GluedFile.{fileType}");
        }
    }
}
