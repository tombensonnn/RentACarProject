var nameList = new List<string>()
{
    "can", "berke", "umut", "oğuz"
};

var orderByList = nameList.OrderBy(g => g);

var firstName = orderByList.ToList().FirstOrDefault();

Console.WriteLine(firstName);