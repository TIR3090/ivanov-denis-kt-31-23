namespace Ivanov_Denis_Evgenievich_KT_31_23.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Student> Students { get; set; } = new List<Student>();
}
