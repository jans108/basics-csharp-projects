namespace Pluralsight.CShPlaybook.Oop;

public interface IPhotoProvider
{
    Image? GetPhoto();
}

public class ModelPhotoProvider : IPhotoProvider
{
    private Image? _photo;
    private string _filePath;

    public ModelPhotoProvider(string fileName)
    {
        _filePath = DataFileFinder.GetFilePath(fileName);
    }

    public Image? GetPhoto()
    {
        if (_photo == null && File.Exists(_filePath))
            _photo = Image.FromFile(_filePath);

        return _photo;
    }
}

