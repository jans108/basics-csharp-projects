using Pluralsight.CShPlaybook.Oop;

namespace Pluralsight.CShPlaybook.Oop;

public class ModelBase
{
    private string _otherInfo = "";

    public string Name { get; }
    public int Id { get; }
    public IPhotoProvider PhotoProvider { get; }

    public ModelBase(int id, string name, string photoFileName)
    {
        Id = id;
        Name = name;
        PhotoProvider = PhotoProviderFactory.Create(photoFileName);
    }

    public override string ToString() => Name;


}

public static class PhotoProviderFactory
{
    public static IPhotoProvider Create(string fileName)
    {
        string filePath = DataFileFinder.GetFilePath(fileName);
        if (File.Exists(filePath))
            return new ModelPhotoProvider(fileName);
        else
            return MissingPhotoProvider.Instance;
    }
}

