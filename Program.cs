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
    if (choice == "q")
    {
        // exit 
        optionNot1thru4 = false;
    }

    else if (choice == "1")
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
    var db = new BloggingContext();
    var blogs = db.Blogs.ToList();

     for (int i = 0; i < blogs.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {blogs[i].Name}");
    }
    Console.Write("Choose which Blog you want to post to: ");
    
    string resp = Console.ReadLine();
    if (int.TryParse(resp, out int selectedBlogIndex) && selectedBlogIndex >= 1 && selectedBlogIndex <= blogs.Count)
        {
            var chosenBlogID = blogs[selectedBlogIndex - 1];
    
            Console.Write("Enter the title of the post: ");
            string title = Console.ReadLine();

            Console.Write("Enter the content of the post: ");
            string content = Console.ReadLine();

            var post = new Post
            {
                Title = title,
                Content = content,
                BlogId = chosenBlogID.BlogId 
            };

            db.Posts.Add(post);
            db.SaveChanges();
            logger.Info("Post created for {blogName} - Title: {title}", chosenBlogID, title);
        }
        else
        {
            Console.WriteLine("Blog not found.");
        }
    }
}
logger.Info("Program ended");

