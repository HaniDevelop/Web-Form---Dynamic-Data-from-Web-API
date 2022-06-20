using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm2
{
    public partial class _Default : Page
    {
        List<Movie> source = new List<Movie>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //FOR TESTING ON OTHER NETWORKS: first run the MoviesAPIProject with IIS Express, copy the local URL from browser,
                    //and paste it here (with /api/ directory at the end):
                    client.BaseAddress = new Uri("https://localhost:44372/api/");

                    //Send a GET request to the web API:
                    var responseTask = client.GetAsync("Movies");
                    responseTask.Wait();

                    //Check Status Code to see if successful
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Movie[]>();
                        readTask.Wait();
                        var movies = readTask.Result;

                        foreach (var m in movies)
                        {
                            source.Add(m);
                        }
                    }
                    else
                    {
                        movieGrid.Visible = false;
                        TextBox1.Text = "Error Code: " + result.StatusCode.ToString() + "   GET request failed";
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(Environment.NewLine + ex.StackTrace + Environment.NewLine);
                movieGrid.Visible = false;
                TextBox1.Text = "Could not connect to API, check client.BaseAddress or make sure web API is running";
            }

            //Bind movie titles to DataGrid
            movieGrid.DataSource = source.Select(x => x.title);
            movieGrid.DataBind();

        }

        protected void movieGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When user selects a row, call ToString method on the corresponding Movie object
            TextBox1.Text = source[movieGrid.SelectedIndex].ToString();
        }
    }
}