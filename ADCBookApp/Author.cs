using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCBookApp
{
    public class Author
    {
        public int authorId { get; set; }
        public string authorName { get; set; }
        public int birstYear { get; set; }
        public string homeTown { get; set; }

        public Author()
        {
        }

        public Author(int authorId, string authorName, int birstYear, string homeTown)
        {
            this.authorId = authorId;
            this.authorName = authorName;
            this.birstYear = birstYear;
            this.homeTown = homeTown;
        }

        public Author(string authorName, int birstYear, string homeTown)
        {
            this.authorName = authorName;
            this.birstYear = birstYear;
            this.homeTown = homeTown;
        }
    }
}
