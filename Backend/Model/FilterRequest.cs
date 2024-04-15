namespace Backend.Model;

public class FilterRequest
{
    public string? Typefood { get; set; }
    
    public Tuple<short, short>? Calories { get; set; }
    
    public List<string?>? ListLoveIngred { get; set; }
    
    public List<string?>? ListNotLoveIngred { get; set; }
    
}