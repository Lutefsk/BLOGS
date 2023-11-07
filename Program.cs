using NLog;
using System.Linq;


string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

bool optionNot1thru4 = true;
while (optionNot1thru4)
{
    Console.WriteLine("1) Display all blogs");
    Console.WriteLine("2) Add Blog");
    Console.WriteLine("3) Create Post");
    Console.WriteLine("4) Display Posts");
    Console.WriteLine("Enter q to quit.");

    string choice = Console.ReadLine();
    if (choice == "1")
    {
    // Display all Blogs from the database
    var db = new BloggingContext();
    var query = db.Blogs.OrderBy(b => b.Name);

    Console.WriteLine("All blogs in the database:");
    foreach (var item in query)
    {
        Console.WriteLine(item.Name);
    }
    }
    else if (choice == "2")
try
{
    // Create and save a new Blog
    Console.Write("Enter a name for a new Blog: ");
    var name = Console.ReadLine();

    var blog = new Blog { Name = name };

    var db = new BloggingContext();
    db.AddBlog(blog);
    logger.Info("Blog added - {name}", name);

}
catch (Exception ex)
{
    logger.Error(ex.Message);
}
else if (choice == "3")
{
    // Post to an existing Blog
    Console.Write("Enter name of Blog you want to post to: ");
}


logger.Info("Program ended");
}
