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
        PhotoProvider = ModelPhotoProvider.PhotoProviderFactory.Create(photoFileName);
    }

    public override string ToString() => Name;


}



