namespace api.models;

public class Values
{
    public string FullName { get; set; }
    public int ID { get; set; }
    public Values(string _fullName,  int _id)
    {
        FullName = _fullName;
        ID = _id;
    }
    
}



