namespace JSON2Model
{
    public interface ILanguage
    {
        string GenerateCode(ClassDefinition classDefinition);
    }
}
