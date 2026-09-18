namespace Ivanov_Denis_Evgenievich_KT_31_23.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int GroupId { get; set; }
    public Group? Group { get; set; }
}
